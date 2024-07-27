using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Cdek delivery order request to create.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/29923926.html"/>
    /// </remarks>
    public record CreateDeliveryOrderRequest
    {
        /// <summary>
        /// Тип заказа:<br/>
        /// 1 - "интернет-магазин" (только для договора типа "Договор с ИМ"),<br/>
        /// 2 - "доставка" (для любого договора).
        /// </summary>
        /// <remarks>
        /// По умолчанию - 1.
        /// </remarks>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonIntEnumConverter<OrderType>))]
        public OrderType? Type { get; set; }

        /// <summary>
        /// Дополнительный тип заказа.
        /// </summary>
        [JsonPropertyName("additional_order_types")]
        [JsonConverter(typeof(JsonIntEnumConverter<AdditionalOrderType>))]
        public AdditionalOrderType? AdditionalOrderTypes { get; set; }

        /// <summary>
        /// Номер заказа в ИС Клиента (если не передан, будет присвоен номер заказа в ИС СДЭК - uuid).<br/>
        /// Только для заказов "интернет-магазин".
        /// </summary>
        /// <remarks>
        /// Может содержать только цифры, буквы латинского алфавита или спецсимволы (формат ASCII).
        /// </remarks>
        [JsonPropertyName("number")]
        public string? Number { get; set; }

        /// <summary>
        /// Код тарифа.
        /// </summary>
        [JsonPropertyName("tariff_code")]
        public int TariffCode { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        /// <remarks>
        /// Для заказов с тарифами "Доставка за 4 часа внутри города пешие", "Доставка за 4 часа МСК-МО МО-МСК пешие", 
        /// "Доставка за 4 часа внутри города авто", "Доставка за 4 часа МСК-МО МО-МСК авто"
        /// в этом поле можно передать желаемый интервал доставки заказа в формате YYYY-MM-DDThh:mm±hh;YYYY-MM-DDThh:mm±hh.<br/>
        /// Иначе по умолчанию будет выбран ближайший интервал к текущему времени.
        /// </remarks>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Ключ разработчика (для разработчиков модулей).
        /// </summary>
        [JsonPropertyName("developer_key")]
        public string? DeveloperKey { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет производиться самостоятельный привоз клиентом.
        /// </summary>
        /// <remarks>
        /// Не может использоваться одновременно с <see cref="FromLocation"/>.
        /// </remarks>
        [JsonPropertyName("shipment_point")]
        public string ShipmentPoint { get; set; }

        /// <summary>
        /// Код офиса СДЭК (ПВЗ/постамата), на который будет доставлена посылка.
        /// </summary>
        /// <remarks>
        ///  Не может использоваться одновременно с <see cref="ToLocation"/>.<br/>
        /// Если офис недоступен, то происходит переадресация на ближайший доступный офис.
        /// </remarks>
        [JsonPropertyName("delivery_point")]
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// Дата инвойса.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        [JsonPropertyName("date_invoice")]
        public DateTime? DateInvoice { get; set; }

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        [JsonPropertyName("shipper_name")]
        public string? ShipperName { get; set; }

        /// <summary>
        /// Адрес грузоотправителя.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов с типом "интернет-магазин". Если поле заполнено, то заказ автоматически становится международным.
        /// </remarks>
        [JsonPropertyName("shipper_address")]
        public string? ShipperAddress { get; set; }

        /// <summary>
        /// Доп. сбор за доставку, которую ИМ берет с получателя.
        /// </summary>
        /// <remarks>
        /// Только для заказов "интернет-магазин".<br/>
        /// Для направлений Беларусь-Беларусь и РФ-Беларусь, это поле игнорируется.
        /// </remarks>
        [JsonPropertyName("delivery_recipient_cost")]
        public DeliveryRecipientCost? DeliveryRecipientCost { get; set; }

        /// <summary>
        /// Доп. сбор за доставку (которую ИМ берет с получателя) в зависимости от суммы заказа.
        /// Только для заказов "интернет-магазин". Возможно указать несколько порогов.
        /// </summary>
        [JsonPropertyName("delivery_recipient_cost_adv")]
        public List<DeliveryRecipientCostAdv> DeliveryRecipientCostAdv { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        [JsonPropertyName("sender")]
        public ContactBase? Sender { get; set; }

        /// <summary>
        /// Реквизиты истинного продавца.
        /// Только для заказов "интернет-магазин".
        /// </summary>
        [JsonPropertyName("seller")]
        public Seller? Seller { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        [JsonPropertyName("recipient")]
        public ContactBase Recipient { get; set; }

        /// <summary>
        /// Адрес отправления.
        /// Не может использоваться одновременно с <see cref="ShipmentPoint"/>.
        /// </summary>
        [JsonPropertyName("from_location")]
        public DeliveryOrderLocation FromLocation { get; set; }

        /// <summary>
        /// Адрес получения.
        /// Не может использоваться одновременно с <see cref="DeliveryPoint"/>.
        /// </summary>
        [JsonPropertyName("to_location")]
        public DeliveryOrderLocation ToLocation { get; set; }

        /// <summary>
        /// Дополнительные услуги.
        /// </summary>
        [JsonPropertyName("services")]
        public List<AdditionalServiceBase>? Services { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам).
        /// Количество мест в заказе может быть от 1 до 255.
        /// </summary>
        [JsonPropertyName("packages")]
        public List<DeliveryOrderPackageRequest> Packages { get; set; }

        /// <summary>
        /// Необходимость сформировать печатную форму по заказу.
        /// </summary>
        [JsonPropertyName("print")]
        [JsonConverter(typeof(JsonEnumValueConverter<PrintType>))]
        public PrintType? Print { get; set; }

        /// <summary>
        /// Клиентский возврат.
        /// </summary>
        /// <remarks>
        /// Необходимо использовать, если прямой заказ доставлялся другой курьерской службой, либо по прямому заказу необходимо вернуть не все товары.<br/>
        /// Иначе необходимо использовать отдельный метод "Клиентские возвраты" <see href="https://api-docs.cdek.ru/122762174.html"/>.
        /// </remarks>
        [JsonPropertyName("is_client_return")]
        public bool? IsClientReturn { get; set; }
    }
}
