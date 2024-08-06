namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order request to update.
    /// </summary>
    public record UpdateDeliveryOrderRequest
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Числовой код тарифа.
        /// </summary>
        public int? NumTariffCode
        {
            get
            {
                if (int.TryParse(TariffCode, out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Код тарифа (режимы старого и нового тарифа должны совпадать).
        /// </summary>
        public string? TariffCode { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет произведен забор отправления либо самостоятельный привоз клиентом.
        /// Не может использоваться одновременно с <see cref="FromLocation"/>.
        /// </summary>
        public string? ShipmentPoint { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет доставлена посылка.
        /// Не может использоваться одновременно с <see cref="ToLocation"/>.
        /// </summary>
        public string? DeliveryPoint { get; set; }

        ///// <summary>
        ///// Дополнительный сбор за доставку, который ИМ берет с получателя.
        ///// Валюта сбора должна совпадать с валютой наложенного платежа.
        ///// </summary>
        //public DeliveryRecipientCost? DeliveryRecipientCost { get; set; }

        ///// <summary>
        ///// Порог стоимости товара для расчета дополнительного сбора за доставку.
        ///// </summary>
        //public List<DeliveryRecipientCostAdv>? DeliveryRecipientCostAdv { get; set; }

        /// <summary>
        /// Информация об отправителе.
        /// </summary>
        public Contact? Sender { get; set; }

        ///// <summary>
        ///// Реквизиты реального продавца.
        ///// </summary>
        //public Seller? Seller { get; set; }

        /// <summary>
        /// Информация о получателе.
        /// </summary>
        public Contact? Recipient { get; set; }

        /// <summary>
        /// Адрес получения.
        /// Не может использоваться одновременно с <see cref="DeliveryPoint"/>.
        /// </summary>
        public DeliveryOrderLocation? ToLocation { get; set; }

        /// <summary>
        /// Адрес отправки.
        /// Не может использоваться одновременно с <see cref="ShipmentPoint"/>.
        /// </summary>
        public DeliveryOrderLocation? FromLocation { get; set; }

        /// <summary>
        /// Дополнительные услуги.
        /// </summary>
        public List<AdditionalServiceRequest>? Services { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам).
        /// </summary>
        public List<DeliveryOrderPackage>? Packages { get; set; }

        /// <summary>
        /// Gets the additional order data.
        /// </summary>
        public List<DeliveryOrderData> AdditionalProviderData { get; } = [];

        /// <summary>
        /// Adds the additional data to update the delivery order.
        /// </summary>
        public UpdateDeliveryOrderRequest WithProviderData(string name, object value)
        {
            AdditionalProviderData.Add(new(name, value));

            return this;
        }
    }
}
