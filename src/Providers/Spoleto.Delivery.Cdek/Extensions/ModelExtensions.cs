namespace Spoleto.Delivery.Providers.Cdek
{
    internal static class ModelExtensions
    {
        public static TariffRequest ToTariffRequest(this Delivery.TariffRequest request)
        {
            return new TariffRequest
            {
                FromLocation = request.FromLocation.ToLocationRequest(),
                ToLocation = request.ToLocation.ToLocationRequest(),
                Packages = request.Packages.Select(x => x.ToPackageRequest()).ToList(),
            };
        }

        public static Location ToLocationRequest(this Delivery.Location location)
        {
            return new Location
            {
                Address = location.Address,
                City = location.City,
                Code = Int32.TryParse(location.Code, out var v) ? v : default,
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
                NumCode = tariff.Code,
                PeriodMin = tariff.PeriodMin,
                PeriodMax = tariff.PeriodMax,
            };
        }

        public static Delivery.City ToDeliveryCity(this City city)
        {
            return new Delivery.City
            {
                Code = city.Code.ToString(),
                NumCode = city.Code,
                Name = city.Name,
                FiasCode = city.FiasId,
                KladrCode = city.KladrCode,
                Country = city.Country,
                Region = city.Region
            };
        }

        public static CityRequest ToCityRequest(this Delivery.CityRequest request)
        {
            return new CityRequest
            {
                City = request.Name,
                Code = request.NumCode,
                PostalCode = request.PostalCode
            };
        }
    }
}
