namespace Spoleto.Delivery
{
    /// <summary>
    /// Запрос на получение доступных тарифов.
    /// </summary>
    public record TariffRequest
    {
        /// <summary>
        /// Тип заказа.
        /// </summary>
        public OrderType? Type { get; set; }

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

        /// <summary>
        /// Сумма страхования.
        /// </summary>
        public decimal? SumInsured { get; set; }

        /// <summary>
        /// Gets the additional order data.
        /// </summary>
        public List<DeliveryOrderData> AdditionalProviderData { get; } = [];

        /// <summary>
        /// Adds the additional data to calculate a delivery order tariff.
        /// </summary>
        public TariffRequest WithProviderData(string name, object value)
        {
            AdditionalProviderData.Add(new(name, value));

            return this;
        }
    }
}
