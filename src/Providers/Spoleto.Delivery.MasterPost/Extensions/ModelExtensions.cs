﻿using Spoleto.Delivery.Helpers;

namespace Spoleto.Delivery.Providers.MasterPost
{
    internal static class ModelExtensions
    {
        public static TariffRequest ToTariffRequest(this Delivery.TariffRequest request)
        {
            var tariffRequest = new TariffRequest
            {
                //SenderAddress = request.FromLocation.Address ?? String.Empty,
                SenderCity = request.FromLocation.CityFiasId?.ToString() ?? request.FromLocation.KladrCode ?? string.Empty,
                //RecipientAddress = request.ToLocation.Address,
                RecipientCity = request.ToLocation.CityFiasId?.ToString() ?? request.FromLocation.KladrCode ?? string.Empty,
                CargoPlaces = request.Packages.Select(x => x.ToCargoPlaceBaseRequest()).ToList(),
                EstimatedCost = request.SumInsured ?? 0M
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
                Weight = package.Weight / 1000M,
                CargoPlaceType = Enum.TryParse<CargoPlaceType>(package.PackageType.ToString(), out var cargoPlaceType) ? cargoPlaceType : CargoPlaceType.Cargo
            };
        }

        public static CargoPlace ToCargoPlace(this Delivery.Package package)
        {
            return new CargoPlace
            {
                Height = package.Height ?? 0,
                Length = package.Length ?? 0,
                Width = package.Width ?? 0,
                Weight = package.Weight / 1000M,
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
                PeriodMin = tariff.DeliveryMinDays,
                PeriodMax = tariff.DeliveryMaxDays,
                PeriodDateMin = tariff.DeliveryMinDateTime,
                PeriodDateMax = tariff.DeliveryMaxDateTime,
                DeliveryMode = DeliveryMode.DoorDoor,
                Services = tariff.Rates.Where(x => x.Price > 0M).Select(x => x.ToDeliveryTariffService()).ToList()
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
                Weight = package.Weight / 1000M,
                CargoPlaceType = package.PackageType == null ? CargoPlaceType.Cargo : (CargoPlaceType)Enum.Parse(typeof(CargoPlaceType), package.PackageType.Value.ToString())
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
                ArticleVatRate = item.Payment.VatRate == null ? VatRate.VAT_20 : (VatRate)item.Payment.VatRate.Value
            };
        }

        public static CreateDeliveryOrderRequest ToCreateOrderRequest(this Delivery.CreateDeliveryOrderRequest request)
        {
            if (request.TariffCode == null)
            {
                throw new ArgumentNullException(nameof(request.TariffCode));
            }

            var orderRequest = new CreateDeliveryOrderRequest
            {
                OrderNumber = GetOrderNumber(request),
                DeliveryMode = request.TariffCode,
                Comment = request.Comment ?? string.Empty,

                SenderAddress = request.FromLocation.Address,
                SenderCity = request.FromLocation.CityFiasId?.ToString() ?? string.Empty,
                SenderStreet = request.FromLocation.StreetFiasId?.ToString() ?? string.Empty,
                SenderContact = request.Sender.Name,
                SenderCompany = request.Sender.Company ?? string.Empty,
                SenderPhone = request.Sender.Phones?.FirstOrDefault().Number,

                RecipientAddress = request.ToLocation.Address,
                RecipientCity = request.ToLocation.CityFiasId?.ToString() ?? string.Empty,
                RecipientStreet = request.ToLocation.StreetFiasId.ToString() ?? string.Empty,
                RecipientCompany = request.Recipient.Company ?? string.Empty,
                RecipientContact = request.Recipient.Name,
                RecipientEmail = request.Recipient.Email,
                RecipientPhone = request.Recipient.Phones?.FirstOrDefault().Number,

                AdditionalServices = request.Services?.Select(x => x.ToAdditionalServiceRequest()).ToList() ?? [],
                Places = request.Packages?.Select(x => x.ToOrderCargoPlaceRequest()).ToList() ?? [],
                Items = request.Packages?.Where(x => x.Items != null).Where(x => x.Items != null).SelectMany(x => x.Items).Select(x => x.ToOrderCargoItem()).ToList() ?? [],

                PaymentType = request.PaymentType == null ? PaymentType.ByContract : (PaymentType)Enum.Parse(typeof(PaymentType), request.PaymentType.Value.ToString()),

                EstimatedCost = request.SumInsured ?? 0M
            };

            if (request.CourierPickupRequest != null)
            {
                orderRequest.CourierPlannedCollectionDate = request.CourierPickupRequest.IntakeDate;
                orderRequest.CourierPlannedCollectionTimeFrom = request.CourierPickupRequest.IntakeTimeFrom;
                orderRequest.CourierPlannedCollectionTimeTo = request.CourierPickupRequest.IntakeTimeTo;
            }

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

        private static string GetOrderNumber(Delivery.CreateDeliveryOrderRequest request)
        {
            var number = request.CisNumber ?? string.Empty;
            
            //todo: ???
            //if (number.Length > 25)
            //{
            //    if (Guid.TryParse(number, out var guid))
            //    {
            //        return Convert.ToBase64String(guid.ToByteArray());
            //    }

            //    throw new ArgumentException($"The length of {request.CisNumber} can't be more than 25 symbols");
            //}

            return number;
        }

        public static Delivery.DeliveryOrder ToDeliveryOrder(this DeliveryOrder order, string serviceUrl)
        {
            return new Delivery.DeliveryOrder
            {
                Number = order.Number,
                Status = order.CurrentStatus,
                IsRemoved = order.CurrentStatus == "Удалено",
                CisNumber = order.CisNumber,
                PlannedDeliveryDate = order.DeliveryMaxDateTime,
                DeliveryDate = order.DeliveryDateTime,
                TrackUrl = order.GetTrackUrl(serviceUrl),
                SumInsured = order.EstimatedCost,
                TotalSum = order.DeliveryCost,
                Services = order.Rates?.Where(x => x.ServicePrice > 0M).Select(x => x.ToDeliveryAdditionalService()).ToList()
            };
        }

        public static Delivery.AdditionalService ToDeliveryAdditionalService(this DeliveryOrderRate rate)
        {
            var isNumber = rate.ServicePrice > 0M;
            return new Delivery.AdditionalService
            {
                Code = rate.ServiceType,
                Name = rate.ServiceType,
                ParameterType = isNumber ? ParameterType.Number : null,
                TotalSum = isNumber ? rate.ServicePrice!.Value + (rate.ServiceVat ?? 0M) : null
            };
        }
    }
}
