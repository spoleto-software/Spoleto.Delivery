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

        public static Delivery.City ToDeliveryCity(this City city)
        {
            return new Delivery.City
            {
                Name = city.Name,
                FiasCode = city.FiasId,
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
    }
}
