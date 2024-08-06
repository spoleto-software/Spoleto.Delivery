using Spoleto.Delivery.Helpers;

namespace Spoleto.Delivery.Providers.Cdek
{
    internal static class ModelExtensions
    {
        public static TariffRequest ToTariffRequest(this Delivery.TariffRequest request)
        {
            var tariffRequest = new TariffRequest
            {
                Type = request.Type == null ? null : (OrderType)Enum.Parse(typeof(OrderType), request.Type.Value.ToString()),
                FromLocation = request.FromLocation.ToLocationRequest(),
                ToLocation = request.ToLocation.ToLocationRequest(),
                Packages = request.Packages.Select(x => x.ToPackageRequest()).ToList(),
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

        public static Location ToLocationRequest(this Delivery.Location location)
        {
            return new Location
            {
                Address = location.Address,
                City = location.City,
                CityCode = Int32.TryParse(location.ProviderLocationCode, out var v) ? v : null,
                CountryCode = location.CountryCode,
                PostalCode = location.PostalCode
            };
        }


        public static Package ToPackageRequest(this Delivery.Package package)
        {
            return new Package
            {
                Height = package.Height,
                Length = package.Length,
                Width = package.Width,
                Weight = package.Weight
            };
        }

        public static Delivery.Tariff ToDeliveryTariff(this Tariff tariff)
        {
            return new Delivery.Tariff
            {
                CalendarMax = tariff.CalendarMax,
                CalendarMin = tariff.CalendarMin,
                Code = tariff.Code.ToString(),
                DeliveryMode = tariff.DeliveryMode,
                DeliverySum = tariff.DeliverySum,
                Description = tariff.Description,
                Name = tariff.Name,
                PeriodMin = tariff.PeriodMin,
                PeriodMax = tariff.PeriodMax,
            };
        }

        public static Delivery.City ToDeliveryCity(this City city)
        {
            return new Delivery.City
            {
                ProviderCityCode = city.Code.ToString(),
                Name = city.Name,
                FiasId = city.FiasId,
                KladrCode = city.KladrCode,
                Country = city.Country,
                Region = city.Region
            };
        }

        public static CityRequest ToCityRequest(this Delivery.CityRequest request)
        {
            var cityRequest = new CityRequest
            {
                City = request.Name,
                PostalCode = request.PostalCode,
                Size = request.Size,
                Page = request.Page,
                Code = request.ProviderCityNumCode,
                FiasId = request.FiasId
            };

            return cityRequest;
        }

        public static DeliveryOrderLocation ToOrderLocationRequest(this Delivery.DeliveryOrderLocation location)
        {
            return new DeliveryOrderLocation
            {
                Address = location.Address,
                City = location.City,
                Code = Int32.TryParse(location.ProviderLocationCode, out var v) ? v : null,
                CountryCode = location.CountryCode,
                PostalCode = location.PostalCode,
                FiasId = location.CityFiasId,
                KladrCode = location.KladrCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Region = location.Region,
                RegionCode = location.RegionCode,
                SubRegion = location.SubRegion
            };
        }

        public static UpdateDeliveryOrderLocation ToUpdateOrderLocationRequest(this Delivery.DeliveryOrderLocation location)
        {
            return new UpdateDeliveryOrderLocation
            {
                Address = location.Address
            };
        }

        public static DeliveryItemPayment ToDeliveryItemPaymentRequest(this Delivery.DeliveryItemPayment itemPayment)
        {
            return new DeliveryItemPayment
            {
                Value = itemPayment.Value,
                VatRate = itemPayment.VatRate,
                VatSum = itemPayment.VatSum
            };
        }

        public static DeliveryPackageItemBase ToDeliveryPackageItemRequest(this Delivery.DeliveryPackageItem item)
        {
            return new DeliveryPackageItemBase
            {
                Amount = item.Amount,
                Brand = item.Brand,
                Cost = item.Cost,
                CountryCode = item.CountryCode,
                Marking = item.Marking,
                Material = item.Material != null ? (MaterialType)Enum.Parse(typeof(MaterialType), item.Material.ToString()) : null,
                Name = item.Name,
                NameI18n = item.NameInternational,
                Url = item.Url,
                WareKey = item.Article,
                Weight = item.Weight,
                WeightGross = item.WeightGross,
                WifiGsm = item.WifiGsm,
                Payment = item.Payment.ToDeliveryItemPaymentRequest()
            };
        }

        public static DeliveryOrderPackageRequest ToOrderPackageRequest(this Delivery.DeliveryOrderPackage package)
        {
            return new DeliveryOrderPackageRequest
            {
                Height = package.Height,
                Length = package.Length,
                Width = package.Width,
                Weight = package.Weight,
                Comment = package.Comment,
                Items = package.Items?.Select(x => x.ToDeliveryPackageItemRequest()).ToList(),
                Number = package.Number
            };
        }

        public static Phone ToPhoneRequest(this Delivery.Phone phone)
        {
            return new Phone
            {
                Number = phone.Number,
                Additional = phone.Additional
            };
        }

        public static ContactBase ToContactRequest(this Delivery.Contact contact)
        {
            return new ContactBase
            {
                Company = contact.Company,
                ContragentType = contact.ContragentType != null ? (ContragentType)Enum.Parse(typeof(ContragentType), contact.ToString()) : null,
                Email = contact.Email,
                Name = contact.Name,
                PassportDateOfBirth = contact.PassportDateOfBirth,
                PassportDateOfIssue = contact.PassportDateOfIssue,
                PassportNumber = contact.PassportNumber,
                PassportOrganization = contact.PassportOrganization,
                PassportSeries = contact.PassportSeries,
                Phones = contact.Phones?.Select(x => x.ToPhoneRequest()).ToList(),
                Tin = contact.Inn
            };
        }

        public static AdditionalService ToAdditionalServiceRequest(this Delivery.AdditionalServiceRequest additionalService)
        {
            return new AdditionalService
            {
                Code = (AdditionalServiceType)Enum.Parse(typeof(AdditionalServiceType), additionalService.Code),
                Parameter = additionalService.Parameter
            };
        }

        public static CreateDeliveryOrderRequest ToOrderRequest(this Delivery.CreateDeliveryOrderRequest request)
        {
            if (request.NumTariffCode == null)
                throw new NullReferenceException(nameof(request.TariffCode));

            var orderRequest = new CreateDeliveryOrderRequest
            {
                Type = request.Type == null ? null : (OrderType)Enum.Parse(typeof(OrderType), request.Type.Value.ToString()),
                FromLocation = request.FromLocation.ToOrderLocationRequest(),
                ToLocation = request.ToLocation.ToOrderLocationRequest(),
                Number = request.Number,
                Packages = request.Packages.Select(x => x.ToOrderPackageRequest()).ToList(),
                Recipient = request.Recipient.ToContactRequest(),
                Sender = request.Sender?.ToContactRequest(),
                Services = request.Services?.Select(x => x.ToAdditionalServiceRequest()).ToList(),
                DeliveryPoint = request.DeliveryPoint,
                ShipmentPoint = request.ShipmentPoint,
                DateInvoice = request.DateInvoice,
                ShipperAddress = request.ShipperAddress,
                ShipperName = request.ShipperName,
                TariffCode = request.NumTariffCode.Value,
                Comment = request.Comment
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


        public static Delivery.Error ToDeliveryError(this Error error)
        {
            return new Delivery.Error
            {
                Code = error.Code,
                Message = error.Message
            };
        }

        public static Delivery.Warning ToDeliveryWarning(this Warning error)
        {
            return new Delivery.Warning
            {
                Code = error.Code,
                Message = error.Message
            };
        }

        public static Delivery.DeliveryOrderRelatedEntity ToDeliveryOrderRelatedEntity(this CreatedDeliveryOrderRelatedEntity entity)
        {
            return new Delivery.DeliveryOrderRelatedEntity
            {
                Type = entity.Type.ToString(),
                Uuid = entity.Uuid
            };
        }

        public static Delivery.DeliveryOrder ToDeliveryOrder(this CreatedDeliveryOrder order)
        {
            return new Delivery.DeliveryOrder
            {
                Uuid = order.Entity.Uuid,
                Errors = order.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = order.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList(),
                //Status = order.Requests?.First().State.ToString(),
                RelatedEntities = order.RelatedEntities?.Select(x => x.ToDeliveryOrderRelatedEntity()).ToList(),
            };
        }

        public static Delivery.DeliveryOrderRelatedEntity ToDeliveryOrderRelatedEntity(this DeliveryOrderRelatedEntity entity)
        {
            return new Delivery.DeliveryOrderRelatedEntity
            {
                Type = entity.Type.ToString(),
                Uuid = entity.Uuid,
                CreateTime = entity.CreateTime
            };
        }

        public static Delivery.DeliveryOrder ToDeliveryOrder(this DeliveryOrder order)
        {
            return new Delivery.DeliveryOrder
            {
                Uuid = order.Entity.Uuid,
                Number = order.Entity.CdekNumber,
                CisNumber = order.Entity.Number,
                Errors = order.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = order.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList(),
                Status = order.Entity?.Statuses?.First().Code.ToString(),
                PlannedDeliveryDate = order.Entity?.PlannedDeliveryDate,
                RelatedEntities = order.RelatedEntities?.Select(x => x.ToDeliveryOrderRelatedEntity()).ToList()
            };
        }

        public static UpdateDeliveryOrderRequest ToOrderRequest(this Delivery.UpdateDeliveryOrderRequest request)
        {
            var orderRequest = new UpdateDeliveryOrderRequest
            {
                Uuid = request.Uuid,
                CdekNumber= request.Number,
                FromLocation = request.FromLocation?.ToUpdateOrderLocationRequest(),
                ToLocation = request.ToLocation?.ToOrderLocationRequest(),
                Packages = request.Packages?.Select(x => x.ToOrderPackageRequest()).ToList(),
                Recipient = request.Recipient?.ToContactRequest(),
                Sender = request.Sender?.ToContactRequest(),
                Services = request.Services?.Select(x => x.ToAdditionalServiceRequest()).ToList(),
                DeliveryPoint = request.DeliveryPoint,
                ShipmentPoint = request.ShipmentPoint,
                TariffCode = request.NumTariffCode,
                Comment = request.Comment
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

        public static Delivery.DeliveryOrder ToDeliveryOrder(this UpdatedDeliveryOrder order)
        {
            return new Delivery.DeliveryOrder
            {
                Uuid = order.Entity.Uuid,
                Errors = order.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = order.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList(),
                //Status = order.Requests?.First().State.ToString()
            };
        }
    }
}
