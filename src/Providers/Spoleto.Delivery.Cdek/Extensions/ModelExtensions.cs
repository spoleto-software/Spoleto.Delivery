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
                DeliveryMode = (Delivery.DeliveryMode)Enum.Parse(typeof(Delivery.DeliveryMode), tariff.DeliveryMode.ToString()),
                DeliverySum = tariff.DeliverySum,
                Description = tariff.Description,
                Name = tariff.Name,
                PeriodMin = tariff.PeriodMin,
                PeriodMax = tariff.PeriodMax,
                PeriodDateMin = DateTimeHelper.GetDateAfterWorkingDays(DateTime.Now.Date, tariff.PeriodMin),
                PeriodDateMax = DateTimeHelper.GetDateAfterWorkingDays(DateTime.Now.Date, tariff.PeriodMax)
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

        public static Delivery.DeliveryPoint ToDeliveryPoint(this DeliveryPoint deliveryPoint)
        {
            return new Delivery.DeliveryPoint
            {
                AddressComment = deliveryPoint.AddressComment,
                AllowedCod = deliveryPoint.AllowedCod,
                Code = deliveryPoint.Code,
                Dimensions = deliveryPoint.Dimensions?.Select(x => x.ToDeliveryDimension()).ToList(),
                Email = deliveryPoint.Email,
                Errors = deliveryPoint.Errors?.Select(x => x.ToDeliveryError()).ToList(),
                Fulfillment = deliveryPoint.Fulfillment,
                HaveCash = deliveryPoint.HaveCash,
                HaveCashless = deliveryPoint.HaveCashless,
                HaveFastPaymentSystem = deliveryPoint.HaveFastPaymentSystem,
                IsDressingRoom = deliveryPoint.IsDressingRoom,
                IsHandout = deliveryPoint.IsHandout,
                IsLtl = deliveryPoint.IsLtl,
                IsReception = deliveryPoint.IsReception,
                Location = deliveryPoint.Location?.ToDeliveryPointLocation(),
                Name = deliveryPoint.Name,
                NearestMetroStation = deliveryPoint.NearestMetroStation,
                NearestStation = deliveryPoint.NearestStation,
                Note = deliveryPoint.Note,
                OfficeImageList = deliveryPoint.OfficeImageList?.Select(x => x.ToDeliveryImageInfo()).ToList(),
                OwnerCode = deliveryPoint.OwnerCode,
                Phones = deliveryPoint.Phones?.Select(x => x.ToDeliveryPhone()).ToList() ?? [],
                Site = deliveryPoint.Site,
                TakeOnly = deliveryPoint.TakeOnly,
                Type = (Delivery.DeliveryPointType)Enum.Parse(typeof(Delivery.DeliveryPointType), deliveryPoint.Type.ToString()),
                Uuid = deliveryPoint.Uuid,
                WeightMax = deliveryPoint.WeightMax,
                WeightMin = deliveryPoint.WeightMin,
                WorkTime = deliveryPoint.WorkTime,
                WorkTimeExceptionList = deliveryPoint.WorkTimeExceptionList?.Select(x => x.ToDeliveryWorkTimeException()).ToList(),
                WorkTimeList = deliveryPoint.WorkTimeList?.Select(x => x.ToDeliveryWorkTime()).ToList() ?? []
            };
        }

        public static Delivery.Phone ToDeliveryPhone(this Phone phone)
        {
            return new()
            {
                Additional = phone.Additional,
                Number = phone.Number
            };
        }

        public static Delivery.Dimension ToDeliveryDimension(this Dimension dimension)
        {
            return new()
            {
                Depth = dimension.Depth,
                Height = dimension.Height,
                Width = dimension.Width
            };
        }

        public static Delivery.DeliveryPointLocation ToDeliveryPointLocation(this DeliveryPointLocation location)
        {
            return new()
            {
                Address = location.Address,
                AddressFull = location.AddressFull,
                City = location.City,
                Region = location.Region,
                ProviderCityCode = location.CityCode.ToString(),
                CountryCode = location.CountryCode,
                FiasId = location.FiasId,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                PostalCode = location.PostalCode,
                ProviderRegionCode = location.RegionCode.ToString()
            };
        }

        public static Delivery.ImageInfo ToDeliveryImageInfo(this ImageInfo imageInfo)
        {
            return new()
            {
                Url = imageInfo.Url
            };
        }

        public static Delivery.WorkTimeException ToDeliveryWorkTimeException(this WorkTimeException workTimeException)
        {
            return new()
            {
                DateEnd = workTimeException.DateEnd,
                DateStart = workTimeException.DateStart,
                IsWorking = workTimeException.IsWorking,
                TimeEnd = workTimeException.TimeEnd,
                TimeStart = workTimeException.TimeStart
            };
        }

        public static Delivery.WorkTime ToDeliveryWorkTime(this WorkTime workTime)
        {
            return new()
            {
                Day = workTime.Day,
                Time = workTime.Time
            };
        }

        public static DeliveryPointRequest ToDeliveryPointRequest(this Delivery.DeliveryPointRequest request)
        {
            var deliveryPointRequest = new DeliveryPointRequest
            {
                AllowedCod = request.AllowedCod,
                CityCode = request.ProviderCityNumCode,
                Code = request.Code,
                CountryCode = request.CountryCode,
                FiasId = request.FiasId,
                Fulfillment = request.Fulfillment,
                HaveCash = request.HaveCash,
                HaveCashless = request.HaveCashless,
                IsDressingRoom = request.IsDressingRoom,
                IsHandout = request.IsHandout,
                IsLtl = request.IsLtl,
                IsReception = request.IsReception,
                PostalCode = request.PostalCode,
                RegionCode = Int32.TryParse(request.ProviderRegionCode, out var r) ? r : null,
                TakeOnly = request.TakeOnly,
                Type = request.Type == null ? null : (DeliveryPointType)Enum.Parse(typeof(DeliveryPointType), request.Type.Value.ToString()),
                WeightMax = request.WeightMax,
                WeightMin = request.WeightMin,
                Page = request.Page,
                Size = request.Size
            };

            return deliveryPointRequest;
        }

        public static DeliveryOrderLocation ToOrderLocationRequest(this Delivery.DeliveryOrderLocation location)
        {
            return new DeliveryOrderLocation
            {
                Address = location.Address,
                City = location.City,
                Code = Int32.TryParse(location.ProviderLocationCode, out var c) ? c : null,
                CountryCode = location.CountryCode,
                PostalCode = location.PostalCode,
                FiasId = location.CityFiasId,
                KladrCode = location.KladrCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Region = location.Region,
                RegionCode = Int32.TryParse(location.ProviderRegionCode, out var r) ? r : null,
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
                CisNumber = package.CisNumber
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
                ContragentType = contact.ContragentType != null ? (ContragentType)Enum.Parse(typeof(ContragentType), contact.ContragentType.ToString()!) : null,
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

        public static CreateDeliveryOrderRequest ToCreateOrderRequest(this Delivery.CreateDeliveryOrderRequest request)
        {
            if (request.NumTariffCode == null)
                throw new NullReferenceException(nameof(request.TariffCode));

            var orderRequest = new CreateDeliveryOrderRequest
            {
                Type = request.Type == null ? null : (OrderType)Enum.Parse(typeof(OrderType), request.Type.Value.ToString()),
                FromLocation = request.FromLocation?.ToOrderLocationRequest(),
                ToLocation = request.ToLocation?.ToOrderLocationRequest(),
                CisNumber = request.CisNumber,
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
                Uuid = order.Entity?.Uuid,
                Number = order.Entity?.CdekNumber,
                CisNumber = order.Entity?.CisNumber,
                Errors = order.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors!)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = order.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings!).Select(x => x.ToDeliveryWarning()).ToList(),
                Status = order.Entity?.Statuses.First().Code.ToString(),
                PlannedDeliveryDate = order.Entity?.PlannedDeliveryDate,
                DeliveryDate = order.Entity?.DeliveryDetail?.Date,
                TrackUrl = order.GetTrackUrl(),
                TotalSum = order.Entity?.DeliveryDetail?.TotalSum,
                RelatedEntities = order.RelatedEntities?.Select(x => x.ToDeliveryOrderRelatedEntity()).ToList(),
                Services = order.Entity?.Services.Select(x => x.ToDeliveryAdditionalServiceRequest()).ToList()
            };
        }

        public static Delivery.AdditionalService ToDeliveryAdditionalServiceRequest(this AdditionalServiceInfo additionalService)
        {
            return new Delivery.AdditionalService
            {
                Code = additionalService.Code.ToString(),
                Parameter = additionalService.Parameter,
                TotalSum = additionalService.TotalSum
            };
        }

        public static UpdateDeliveryOrderRequest ToUpdateOrderRequest(this Delivery.UpdateDeliveryOrderRequest request)
        {
            var orderRequest = new UpdateDeliveryOrderRequest
            {
                Uuid = request.Uuid,
                CdekNumber = request.Number,
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
            };
        }

        public static CreateCourierPickupRequest ToCreatePickupRequest(this Delivery.CreateCourierPickupRequest request)
        {
            return new()
            {
                OrderUuid = request.OrderUuid,
                CdekOrderNumber = request.OrderNumber,
                FromLocation = request.FromLocation?.ToPickupLocationRequest(),
                Sender = request.Sender?.ToPickupContactRequest(),
                Comment = request.Comment,
                CourierPowerOfAttorney = request.CourierPowerOfAttorney,
                CourierIdentityCard = request.CourierIdentityCard,
                Height = request.Height,
                IntakeDate = request.IntakeDate,
                IntakeTimeFrom = request.IntakeTimeFrom,
                IntakeTimeTo = request.IntakeTimeTo,
                Length = request.Length,
                LunchTimeFrom = request.LunchTimeFrom,
                LunchTimeTo = request.LunchTimeTo,
                Name = request.Name,
                NeedCall = request.NeedCall,
                Weight = request.Weight,
                Width = request.Width
            };
        }

        public static CourierPickupLocation ToPickupLocationRequest(this Delivery.CourierPickupLocation location)
        {
            return new()
            {
                Address = location.Address,
                City = location.City,
                CityCode = Int32.TryParse(location.ProviderLocationCode, out var v) ? v : null,
                CountryCode = location.CountryCode,
                PostalCode = location.PostalCode,
                RegionCode = Int32.TryParse(location.ProviderRegionCode, out var r) ? r : null,
                FiasId = location.CityFiasId,
                KladrCode = location.KladrCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Region = location.Region,
                SubRegion = location.SubRegion
            };
        }

        public static CourierPickupContact ToPickupContactRequest(this Delivery.ContactBase contact)
        {
            return new()
            {
                Company = contact.Company,
                ContragentType = contact.ContragentType != null ? (ContragentType)Enum.Parse(typeof(ContragentType), contact.ContragentType.ToString()!) : null,
                Name = contact.Name,
                Phones = contact.Phones?.Select(x => x.ToPhoneRequest()).ToList(),
            };
        }

        public static Delivery.CourierPickup ToDeliveryCourierPickup(this CreatedCourierPickup courierPickup)
        {
            return new()
            {
                Uuid = courierPickup.Entity.Uuid,
                Errors = courierPickup.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = courierPickup.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList()
            };
        }

        public static Delivery.CourierPickup ToDeliveryCourierPickup(this CourierPickup courierPickup)
        {
            return new()
            {
                Uuid = courierPickup.Entity.Uuid,
                Errors = courierPickup.Requests?.Where(x => x.Errors != null).SelectMany(x => x.Errors)?.Select(x => x.ToDeliveryError()).ToList(),
                Warnings = courierPickup.Requests?.Where(x => x.Warnings != null).SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList(),
                Status = courierPickup.Entity.Statuses.First().Code.ToString(),
                Comment = courierPickup.Entity.Comment,
                CourierIdentityCard = courierPickup.Entity.CourierIdentityCard,
                CourierPowerOfAttorney = courierPickup.Entity.CourierPowerOfAttorney,
                FromLocation = courierPickup.Entity.FromLocation.ToDeliveryPickupLocation(),
                Height = courierPickup.Entity.Height,
                IntakeDate = courierPickup.Entity.IntakeDate,
                IntakeTimeFrom = courierPickup.Entity.IntakeTimeFrom,
                IntakeTimeTo = courierPickup.Entity.IntakeTimeTo,
                Length = courierPickup.Entity.Length,
                LunchTimeFrom = courierPickup.Entity.LunchTimeFrom,
                LunchTimeTo = courierPickup.Entity.LunchTimeTo,
                Name = courierPickup.Entity.Name,
                NeedCall = courierPickup.Entity.NeedCall,
                Number = courierPickup.Entity.CdekNumber,
                OrderNumber = courierPickup.Entity.OrderCdekNumber,
                OrderUuid = courierPickup.Entity.OrderUuid,
                Sender = courierPickup.Entity.Sender.ToDeliveryPickupContact(),
                Weight = courierPickup.Entity.Weight,
                Width = courierPickup.Entity.Width

            };
        }

        public static Delivery.CourierPickupLocation? ToDeliveryPickupLocation(this CourierPickupLocation location)
        {
            if (location == null)
                return null;

            return new()
            {
                Address = location.Address,
                City = location.City,
                ProviderLocationCode = location.CityCode?.ToString(),
                CountryCode = location.CountryCode,
                PostalCode = location.PostalCode,
                ProviderRegionCode = location.RegionCode?.ToString(),
                CityFiasId = location.FiasId,
                KladrCode = location.KladrCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Region = location.Region,
                SubRegion = location.SubRegion
            };
        }

        public static Delivery.ContactBase? ToDeliveryPickupContact(this CourierPickupContact contact)
        {
            if (contact == null)
                return null;

            return new()
            {
                Company = contact.Company,
                ContragentType = contact.ContragentType != null ? (Delivery.ContragentType)Enum.Parse(typeof(Delivery.ContragentType), contact.ContragentType.ToString()!) : null,
                Name = contact.Name,
                Phones = contact.Phones?.Select(x => x.ToDeliveryPhone()).ToList(),
            };
        }

        public static Delivery.CreateCourierPickupRequest ToDeliveryCreatePickupRequest(this Delivery.CourierPickupRequest request, Guid orderUuid)
        {
            return new()
            {
                OrderUuid = orderUuid,
                Comment = request.Comment,
                CourierIdentityCard = request.CourierIdentityCard,
                CourierPowerOfAttorney = request.CourierPowerOfAttorney,
                IntakeDate = request.IntakeDate,
                IntakeTimeFrom = request.IntakeTimeFrom,
                IntakeTimeTo = request.IntakeTimeTo,
                LunchTimeFrom = request.LunchTimeFrom,
                LunchTimeTo = request.LunchTimeTo,
                NeedCall = request.NeedCall
            };
        }
    }
}
