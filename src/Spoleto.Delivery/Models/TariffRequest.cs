namespace Spoleto.Delivery
{
    /// <summary>
    /// Запрос на получение доступных тарифов.
    /// </summary>
    public record TariffRequest
    {
        /// <summary>
        /// Адрес отправления
        /// </summary>
        public Location FromLocation { get; set; }

        /// <summary>
        /// Адрес получения
        /// </summary>
        public Location ToLocation { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам)
        /// </summary>
        public List<Package> Packages { get; set; }
    }
}
