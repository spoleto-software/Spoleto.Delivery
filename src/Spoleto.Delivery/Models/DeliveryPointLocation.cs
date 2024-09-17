namespace Spoleto.Delivery
{
    /// <summary>
    /// Адрес офиса
    /// </summary>
    public record DeliveryPointLocation
    {
        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2 (2 символа).
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Код региона в ИС транспортной компании.
        /// </summary>
        public string ProviderRegionCode { get; set; }

        /// <summary>
        /// Название региона.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Код населенного пункта в ИС транспортной компании.
        /// </summary>
        public string ProviderCityCode { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Код города ФИАС (UUID).
        /// </summary>
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Почтовый индекс (до 6 символов).
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Координаты местоположения (долгота) в градусах.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Координаты местоположения (широта) в градусах.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Адрес (улица, дом, офис) в указанном городе.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Полный адрес с указанием страны, региона, города и т.д..
        /// </summary>
        public string AddressFull { get; set; }
    }
}