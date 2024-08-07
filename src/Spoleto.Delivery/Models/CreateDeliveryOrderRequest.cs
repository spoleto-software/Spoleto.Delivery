namespace Spoleto.Delivery
{
    /// <summary>
    /// The delivery order request to create.
    /// </summary>
    public record CreateDeliveryOrderRequest
    {
        /// <summary>
        /// Тип заказа.
        /// </summary>
        public OrderType? Type { get; set; }

        /// <summary>
        /// Способ оплаты
        /// </summary>
        public PaymentType? PaymentType { get; set; }

        ///// <summary>
        ///// Дополнительный тип заказа.
        ///// </summary>
        //public AdditionalOrderType? AdditionalOrderTypes { get; set; }

        /// <summary>
        /// Номер заказа в ИС Клиента.
        /// </summary>
        /// <remarks>
        /// Может содержать только цифры, буквы латинского алфавита или спецсимволы (формат ASCII).
        /// </remarks>
        public string? CisNumber { get; set; }

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
        /// Код тарифа.
        /// </summary>
        public string? TariffCode { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        /// <remarks>
        /// Для заказов с тарифами "Доставка за 4 часа внутри города пешие", "Доставка за 4 часа МСК-МО МО-МСК пешие", 
        /// "Доставка за 4 часа внутри города авто", "Доставка за 4 часа МСК-МО МО-МСК авто"
        /// в этом поле можно передать желаемый интервал доставки заказа в формате YYYY-MM-DDThh:mm±hh;YYYY-MM-DDThh:mm±hh.<br/>
        /// Иначе по умолчанию будет выбран ближайший интервал к текущему времени.
        /// </remarks>
        public string? Comment { get; set; }

        ///// <summary>
        ///// Ключ разработчика (для разработчиков модулей).
        ///// </summary>
        //public string? DeveloperKey { get; set; }

        /// <summary>
        /// Код ПВЗ, на который будет производиться самостоятельный привоз клиентом.
        /// </summary>
        /// <remarks>
        /// Не может использоваться одновременно с <see cref="FromLocation"/>.
        /// </remarks>
        public string ShipmentPoint { get; set; }

        /// <summary>
        /// Код офиса (ПВЗ/постамата), на который будет доставлена посылка.
        /// </summary>
        /// <remarks>
        ///  Не может использоваться одновременно с <see cref="ToLocation"/>.<br/>
        /// Если офис недоступен, то происходит переадресация на ближайший доступный офис.
        /// </remarks>
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// Дата инвойса.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        public DateTime? DateInvoice { get; set; }

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        public string? ShipperName { get; set; }

        /// <summary>
        /// Адрес грузоотправителя.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        public string? ShipperAddress { get; set; }

        ///// <summary>
        ///// Доп. сбор за доставку, которую ИМ берет с получателя.
        ///// </summary>
        ///// <remarks>
        ///// Только для заказов "интернет-магазин".<br/>
        ///// Для направлений Беларусь-Беларусь и РФ-Беларусь, это поле игнорируется.
        ///// </remarks>
        //public DeliveryRecipientCost? DeliveryRecipientCost { get; set; }

        ///// <summary>
        ///// Доп. сбор за доставку (которую ИМ берет с получателя) в зависимости от суммы заказа.
        ///// Только для заказов "интернет-магазин". Возможно указать несколько порогов.
        ///// </summary>
        //public List<DeliveryRecipientCostAdv> DeliveryRecipientCostAdv { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        public Contact? Sender { get; set; }

        ///// <summary>
        ///// Реквизиты истинного продавца.
        ///// Только для заказов "интернет-магазин".
        ///// </summary>
        //public Seller? Seller { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        public Contact Recipient { get; set; }

        /// <summary>
        /// Адрес отправления.
        /// Не может использоваться одновременно с <see cref="ShipmentPoint"/>.
        /// </summary>
        public DeliveryOrderLocation FromLocation { get; set; }

        /// <summary>
        /// Адрес получения.
        /// Не может использоваться одновременно с <see cref="DeliveryPoint"/>.
        /// </summary>
        public DeliveryOrderLocation ToLocation { get; set; }

        /// <summary>
        /// Дополнительные услуги.
        /// </summary>
        public List<AdditionalServiceRequest> Services { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам).
        /// Количество мест в заказе может быть от 1 до 255.
        /// </summary>
        public List<DeliveryOrderPackage> Packages { get; set; }

        ///// <summary>
        ///// Необходимость сформировать печатную форму по заказу.
        ///// </summary>
        //public PrintType? Print { get; set; }

        ///// <summary>
        ///// Клиентский возврат.
        ///// </summary>
        ///// <remarks>
        ///// Необходимо использовать, если прямой заказ доставлялся другой курьерской службой, либо по прямому заказу необходимо вернуть не все товары.<br/>
        ///// Иначе необходимо использовать отдельный метод "Клиентские возвраты" <see href="https://api-docs.cdek.ru/122762174.html"/>.
        ///// </remarks>
        //public bool? IsClientReturn { get; set; }

        /// <summary>
        /// Gets the additional order data.
        /// </summary>
        public List<DeliveryOrderData> AdditionalProviderData { get; } = [];

        /// <summary>
        /// Adds the additional data to create a delivery order..
        /// </summary>
        public CreateDeliveryOrderRequest WithProviderData(string name, object value)
        {
            AdditionalProviderData.Add(new(name, value));

            return this;
        }
    }
}
