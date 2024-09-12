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
        /// Код региона СДЭК.
        /// </summary>
        public int RegionCode { get; set; }

        /// <summary>
        /// Название региона.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Код населенного пункта СДЭК.
        /// </summary>
        public int CityCode { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Код города ФИАС (UUID).
        /// </summary>
        public Guid? FiasGuid { get; set; }

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

        /// <summary>
        /// Идентификатор города (UUID).
        /// </summary>
        public Guid? CityUuid { get; set; }
    }
}