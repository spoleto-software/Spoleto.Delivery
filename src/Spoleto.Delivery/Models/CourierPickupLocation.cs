namespace Spoleto.Delivery
{
    /// <summary>
    /// Класс для представления локации (местоположения) для оформления заявки на вызов курьера на забор груза.
    /// </summary>
    public record CourierPickupLocation : Location
    {
        /// <summary>
        /// Долгота.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Широта.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Название региона, уточняющий параметр для поля <see cref="City"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="City"/>.
        ///  </remarks>
        public string? Region { get; set; }

        /// <summary>
        /// Код региона, уточняющий параметр для поля <see cref="City"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="City"/>.
        ///  </remarks>
        public string? ProviderRegionCode { get; set; }

        /// <summary>
        /// Название района региона, уточняющий параметр для поля <see cref="Region"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="Region"/>.
        ///  </remarks>
        public string? SubRegion { get; set; }
    }
}
