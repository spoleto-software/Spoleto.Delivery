namespace Spoleto.Delivery
{
    /// <summary>
    /// Класс для представления локации (местоположения) для оформления заказа.
    /// </summary>
    public record DeliveryOrderLocation : Location
    {
        /// <summary>
        /// Уникальный идентификатор ФИАС улицы.
        /// </summary>
        public Guid? StreetFiasId { get; set; }

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
        /// Код региона СДЭК, уточняющий параметр для поля <see cref="City"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="City"/>.
        ///  </remarks>
        public int? RegionCode { get; set; }

        /// <summary>
        /// Название района региона, уточняющий параметр для поля <see cref="Region"/>.
        /// </summary>
        /// <remarks>
        ///  Не может быть передано без <see cref="Region"/>.
        ///  </remarks>
        public string? SubRegion { get; set; }
    }
}
