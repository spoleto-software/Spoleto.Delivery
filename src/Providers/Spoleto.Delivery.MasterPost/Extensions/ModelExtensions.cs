namespace Spoleto.Delivery.Providers.MasterPost
{
    internal static class ModelExtensions
    {
        public static TariffCalcRequest ToTariffCalcRequest(this Delivery.TariffRequest request)
        {
            return new TariffCalcRequest
            {
                SenderAddress = request.FromLocation.Address,
                ReceiverAddress = request.ToLocation.Address,
                SenderAddressCode = request.FromLocation.Code,
                ReceiverCity = request.FromLocation.City,
                CargoPlaces = request.Packages.Select(x => x.ToCargoPlaceBaseRequest()).ToList(),
            };
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
                CalendarMax = tariff.CalendarMax,
                CalendarMin = tariff.CalendarMin,
                Code = tariff.Code.ToString(),
                DeliveryMode = tariff.DeliveryMode,
                DeliverySum = tariff.DeliverySum,
                Description = tariff.Description,
                Name = tariff.Name,
                NumCode = tariff.Code,
                PeriodMin = tariff.PeriodMin,
                PeriodMax = tariff.PeriodMax,
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
                FiasCode = city.FiasGuid,
                KladrCode = city.KladrCode,
                Region = city.Region,
                Country = city.Country
            };
        }

        public static CityRequest ToCityRequest(this Delivery.CityRequest request)
        {
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
                Id = package.Number,
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

        public static DeliveryOrderRequest ToOrderRequest(this Delivery.DeliveryOrderRequest request)
        {
            return new DeliveryOrderRequest
            {
                OrderNumber = request.Number,
                DeliveryMode = request.TariffCode,
                Comment                = request.Comment,

                SenderAddress = request.FromLocation.Address,
                SenderAddressCode = request.FromLocation.Code,
                SenderCity = request.FromLocation.City,
                SenderContact = request.Sender.Name,
                SenderCompany = request.Sender.Company,
                SenderPhone = request.Sender.Phones?.FirstOrDefault().Number,

                RecipientAddress = request.ToLocation.Address,
                RecipientCity = request.ToLocation.City,
                RecipientCompany = request.Recipient.Company,
                RecipientContact = request.Recipient.Name,
                RecipientEmail = request.Recipient.Email,
                RecipientPhone = request.Recipient.Phones?.FirstOrDefault().Number,
                
                AdditionalServices = request.Services.Select(x=>x.ToAdditionalServiceRequest()).ToList(),
                Places = request.Packages.Select(x=>x.ToOrderCargoPlaceRequest()).ToList(),
                Items = request.Packages?.Where(x=>x.Items != null).SelectMany(x=>x.Items).Select(x=>x.ToOrderCargoItem()).ToList(),
                //FromLocation = request.FromLocation.ToOrderLocationRequest(),
                //ToLocation = request.ToLocation.ToOrderLocationRequest(),
                //Number = request.Number,
                //Packages = request.Packages.Select(x => x.ToOrderPackageRequest()).ToList(),
                //Recipient = request.Recipient.ToContactRequest(),
                //Sender = request.Sender?.ToContactRequest(),
                //Services = request.Services?.Select(x => x.ToAdditionalServiceRequest()).ToList(),
                //DeliveryPoint = request.DeliveryPoint,
                //ShipmentPoint = request.ShipmentPoint,
                //TariffCode = request.NumTariffCode.Value,
                //Comment = request.Comment
            };
        }


        //public static Delivery.Error ToDeliveryError(this Error error)
        //{
        //    return new Delivery.Error
        //    {
        //        Code = error.Code,
        //        Message = error.Message
        //    };
        //}

        //public static Delivery.Warning ToDeliveryWarning(this Warning error)
        //{
        //    return new Delivery.Warning
        //    {
        //        Code = error.Code,
        //        Message = error.Message
        //    };
        //}

        //public static Delivery.DeliveryOrderRelatedEntity ToDeliveryDeliveryOrderRelatedEntity(this DeliveryOrderRelatedEntity entity)
        //{
        //    return new Delivery.DeliveryOrderRelatedEntity
        //    {
        //        Type = entity.Type.ToString(),
        //        Uuid = entity.Uuid
        //    };
        //}

        public static Delivery.DeliveryOrder ToDeliveryOrder(this DeliveryOrder order)
        {
            return new Delivery.DeliveryOrder
            {
                //Uuid = order.Entity.Uuid,
                //Errors = order.Requests?.SelectMany(x => x.Errors).Select(x => x.ToDeliveryError()).ToList(),
                //Warnings = order.Requests?.SelectMany(x => x.Warnings).Select(x => x.ToDeliveryWarning()).ToList(),
                //Status = order.Requests?.FirstOrDefault().State.ToString(),
                //RelatedEntities = order.RelatedEntities?.Select(x => x.ToDeliveryDeliveryOrderRelatedEntity()).ToList()
            };
        }
    }
}
