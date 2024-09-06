using Spoleto.Delivery.Helpers;

namespace Spoleto.Delivery.Providers.MasterPost
{
    internal static class ModelExtensions
    {
        public static TariffRequest ToTariffRequest(this Delivery.TariffRequest request)
        {
            var tariffRequest = new TariffRequest
            {
                SenderAddress = request.FromLocation.Address ?? String.Empty,
                SenderCity = request.FromLocation.CityFiasId?.ToString() ?? request.FromLocation.KladrCode ?? string.Empty,
                //ReceiverAddress = request.ToLocation.Address,
                ReceiverCity = request.ToLocation.CityFiasId?.ToString() ?? request.FromLocation.KladrCode ?? string.Empty,
                CargoPlaces = request.Packages.Select(x => x.ToCargoPlaceBaseRequest()).ToList()
            };

            var providerData = request.AdditionalProviderData;
            if (providerData?.Count > 0)
            {
                foreach (var data in providerData)
                {
                    ReflectionHelper.SetPropertyValue(tariffRequest, data.Name, data.Value);
                }
            }

            return tariffRequest;
        }

        public static CargoPlaceBase ToCargoPlaceBaseRequest(this Delivery.Package package)
        {
            return new CargoPlaceBase
            {
                Height = package.Height ?? 0,
                Length = package.Length ?? 0,
                Width = package.Width ?? 0,
                Weight = package.Weight,
                CargoPlaceType = Enum.TryParse<CargoPlaceType>(package.PackageType.ToString(), out var cargoPlaceType) ? cargoPlaceType : CargoPlaceType.Cargo
            };
        }

        public static CargoPlace ToCargoPlaceRequest(this Delivery.Package package)
        {
            return new CargoPlace
            {
                Height = package.Height ?? 0,
                Length = package.Length ?? 0,
                Width = package.Width ?? 0,
                Weight = package.Weight,
                CargoPlaceType = Enum.TryParse<CargoPlaceType>(package.PackageType.ToString(), out var cargoPlaceType) ? cargoPlaceType : CargoPlaceType.Cargo
            };
        }

        public static Delivery.Tariff ToDeliveryTariff(this Tariff tariff)
        {
            return new Delivery.Tariff
            {
                Code = tariff.Name,
                DeliverySum = tariff.Cost,
                Name = tariff.Name,
                DeliveryMode = DeliveryMode.DoorToDoor,
                Services = tariff.Rates.Select(x => x.ToDeliveryTariffService()).ToList()
            };
        }

        public static Delivery.TariffService ToDeliveryTariffService(this TariffRate tariffRate)
        {
            return new Delivery.TariffService
            {
                Coefficient = tariffRate.Coefficient,
                Price = tariffRate.Price,
                RatePart = tariffRate.RatePart,
                Vat = tariffRate.Vat
            };
        }

        public static Delivery.AdditionalService ToDeliveryAdditionalService(this AdditionalService tariff)
        {
            return new Delivery.AdditionalService
            {
                Name = tariff.Name,
                Code = tariff.Name
            };
        }

        public static Delivery.City ToDeliveryCity(this City city)
        {
            return new Delivery.City
            {
                Name = city.Name,
                FiasId = city.FiasId,
                KladrCode = city.KladrCode,
                Region = city.Region,
                Country = city.Country
            };
        }

        public static CityRequest ToCityRequest(this Delivery.CityRequest request)
        {
            if (request.Size != null && request.Page != null)
            {
                throw new NotSupportedException($"MasterPost.GetCities does not support parameters: <{nameof(request.Page)}>, <{nameof(request.Size)}>.");
            }

            if (request.Size != null)
            {
                throw new NotSupportedException($"MasterPost.GetCities does not support parameter <{nameof(request.Size)}>.");
            }

            if (request.Page != null)
            {
                throw new NotSupportedException($"MasterPost.GetCities does not support parameter <{nameof(request.Page)}>.");
            }

            return new CityRequest
            {
                Filter = request.Name //todo: только ли имя передавать в фильтр?
            };
        }

        public static AdditionalServiceBase ToAdditionalServiceRequest(this Delivery.AdditionalServiceRequest additionalService)
        {
            return new AdditionalServiceBase
            {
                Name = additionalService.Code
            };
        }

        public static CargoPlace ToOrderCargoPlaceRequest(this Delivery.DeliveryOrderPackage package)
        {
            return new CargoPlace
            {
                Id = package.CisNumber,
                Height = package.Height ?? 0,
                Length = package.Length ?? 0,
                Width = package.Width ?? 0,
                Weight = package.Weight,
                CargoPlaceType = package.CargoPlaceType == null ? CargoPlaceType.Cargo : (CargoPlaceType)Enum.Parse(typeof(CargoPlaceType), package.CargoPlaceType.Value.ToString())
            };
        }

        public static CargoItem ToOrderCargoItem(this Delivery.DeliveryPackageItem item)
        {
            return new CargoItem
            {
                ArticleName = item.Name,
                ArticleNumber = item.Article,
                ArticleMarkingCode = item.Marking,
                ArticleQuantity = item.Amount,
                ArticleEstimatedPrice = item.Cost,
                ArticlePriceWithVat = item.Payment.Value,
                ArticlePriceWithoutVat = item.Payment.Value - (item.Payment.VatSum ?? 0M),
                ArticleVatRate = item.Payment.VatRate == null ? VatRate.WO_VAT : (VatRate)item.Payment.VatRate.Value
            };
        }

        public static CreateDeliveryOrderRequest ToOrderRequest(this Delivery.CreateDeliveryOrderRequest request)
        {
            if (request.TariffCode == null)
            {
                throw new ArgumentNullException(nameof(request.TariffCode));
            }

            var orderRequest = new CreateDeliveryOrderRequest
            {
                OrderNumber = request.CisNumber ?? string.Empty,
                DeliveryMode = request.TariffCode,
                Comment = request.Comment ?? string.Empty,

                SenderAddress = request.FromLocation.Address,
                SenderCity = request.FromLocation.CityFiasId?.ToString() ?? string.Empty,
                SenderStreet = request.FromLocation.StreetFiasId?.ToString() ?? string.Empty,
                SenderContact = request.Sender.Name,
                SenderCompany = request.Sender.Company,
                SenderPhone = request.Sender.Phones?.FirstOrDefault().Number,

                RecipientAddress = request.ToLocation.Address,
                RecipientCity = request.ToLocation.CityFiasId?.ToString() ?? string.Empty,
                RecipientStreet = request.ToLocation.StreetFiasId.ToString() ?? string.Empty,
                RecipientCompany = request.Recipient.Company,
                RecipientContact = request.Recipient.Name,
                RecipientEmail = request.Recipient.Email,
                RecipientPhone = request.Recipient.Phones?.FirstOrDefault().Number,

                AdditionalServices = request.Services?.Select(x => x.ToAdditionalServiceRequest()).ToList() ?? [],
                Places = request.Packages?.Select(x => x.ToOrderCargoPlaceRequest()).ToList() ?? [],
                Items = request.Packages?.Where(x => x.Items != null).Where(x => x.Items != null).SelectMany(x => x.Items).Select(x => x.ToOrderCargoItem()).ToList() ?? [],

                PaymentType = request.PaymentType == null ? PaymentType.CashRecipient : (PaymentType)Enum.Parse(typeof(PaymentType), request.PaymentType.Value.ToString()),
            };

            var providerData = request.AdditionalProviderData;
            if (providerData?.Count > 0)
            {
                foreach (var data in providerData)
                {
                    ReflectionHelper.SetPropertyValue(orderRequest, data.Name, data.Value);
                }
            }

            return orderRequest;
        }

        public static Delivery.DeliveryOrder ToDeliveryOrder(this DeliveryOrder order, string serviceUrl)
        {
            return new Delivery.DeliveryOrder
            {
                Number = order.Number,
                Status = order.CurrentStatus,
                CisNumber = order.CisNumber,
                PlannedDeliveryDate = order.DeliveryDateTime,
                TrackUrl = order.GetTrackUrl(serviceUrl)
            };
        }
    }
}
