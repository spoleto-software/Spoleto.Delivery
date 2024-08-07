using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Информация о заказе
    /// </summary>
    public record DeliveryOrderEntity
    {
        /// <summary>
        /// Идентификатор заказа в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Признак возвратного заказа: true - возвратный, false - прямой.
        /// </summary>
        [JsonPropertyName("is_return")]
        public bool IsReturn { get; set; }

        /// <summary>
        /// Признак реверсного заказа: true - реверсный, false - не реверсный.
        /// </summary>
        [JsonPropertyName("is_reverse")]
        public bool IsReverse { get; set; }

        /// <summary>
        /// Признак клиентского возврата.
        /// </summary>
        [JsonPropertyName("is_client_return")]
        public bool IsClientReturn { get; set; }

        /// <summary>
        /// Тип заказа: 1 - "интернет-магазин", 2 - "доставка".
        /// </summary>
        [JsonPropertyName("type")]
        public OrderType Type { get; set; }

        /// <summary>
        /// Дополнительный тип заказа: 4 - Forward, 6 - "Фулфилмент. Приход", 7 - "Фулфилмент. Отгрузка".
        /// </summary>
        [JsonPropertyName("additional_order_types")]
        public AdditionalOrderType? AdditionalOrderTypes { get; set; }

        /// <summary>
        /// Номер заказа СДЭК.
        /// </summary>
        [JsonPropertyName("cdek_number")]
        public string? CdekNumber { get; set; }

        /// <summary>
        /// Номер заказа в ИС Клиента.
        /// </summary>
        [JsonPropertyName("number")]
        public string? CisNumber { get; set; }

        /// <summary>
        /// Истинный режим заказа.
        /// </summary>
        /// <remarks>
        /// 1 - дверь-дверь<br/>
        /// 2 - дверь-склад<br/>
        /// 3 - склад-дверь<br/>
        /// 4 - склад-склад<br/>
        /// 6 - дверь-постамат<br/>
        /// 7 - склад-постамат<br/>
        /// 8 - постамат-дверь<br/>
        /// 9 - постамат-склад<br/>
        /// 10 - постамат-постамат
        /// </remarks>
        [JsonPropertyName("delivery_mode")]
        public string? DeliveryMode { get; set; }

        /// <summary>
        /// Код тарифа.
        /// </summary>
        [JsonPropertyName("tariff_code")]
        public int TariffCode { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        /// <remarks>
        /// Для заказов с тарифами Блиц 01-04, в этом поле можно передать желаемый интервал доставки заказа в формате YYYY-MM-DDThh:mm±hh;YYYY-MM-DDThh:mm±hh.<br/>
        /// Иначе по умолчанию будет выбран ближайший интервал к текущему времени. 
        /// </remarks>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Ключ разработчика.
        /// </summary>
        [JsonPropertyName("developer_key")]
        public string? DeveloperKey { get; set; }

        /// <summary>
        /// Код ПВЗ СДЭК, на который будет производиться самостоятельный привоз клиентом.
        /// </summary>
        [JsonPropertyName("shipment_point")]
        public string? ShipmentPoint { get; set; }

        /// <summary>
        /// Код офиса СДЭК (ПВЗ/постамат), на который будет доставлена посылка.
        /// </summary>
        [JsonPropertyName("delivery_point")]
        public string? DeliveryPoint { get; set; }

        /// <summary>
        /// Дата инвойса (Только для международных заказов).
        /// </summary>
        [JsonPropertyName("date_invoice")]
        public DateTime? DateInvoice { get; set; }

        /// <summary>
        /// Грузоотправитель (Только для международных заказов).
        /// </summary>
        [JsonPropertyName("shipper_name")]
        public string? ShipperName { get; set; }

        /// <summary>
        /// Адрес грузоотправителя (Только для международных заказов).
        /// </summary>
        [JsonPropertyName("shipper_address")]
        public string? ShipperAddress { get; set; }

        /// <summary>
        /// Доп. сбор за доставку, которую ИМ берет с получателя.
        /// </summary>
        [JsonPropertyName("delivery_recipient_cost")]
        public DeliveryRecipientCost? DeliveryRecipientCost { get; set; }

        /// <summary>
        /// Доп. сбор за доставку (которую ИМ берет с получателя), в зависимости от суммы заказа.
        /// </summary>
        [JsonPropertyName("delivery_recipient_cost_adv")]
        public List<DeliveryRecipientCostAdv>? DeliveryRecipientCostAdv { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        [JsonPropertyName("sender")]
        public Contact Sender { get; set; }

        /// <summary>
        /// Реквизиты истинного продавца.
        /// </summary>
        [JsonPropertyName("seller")]
        public Seller Seller { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        [JsonPropertyName("recipient")]
        public Contact Recipient { get; set; }

        /// <summary>
        /// Адрес отправления.
        /// </summary>
        [JsonPropertyName("from_location")]
        public DeliveryOrderLocation FromLocation { get; set; }

        /// <summary>
        /// Адрес получения.
        /// </summary>
        [JsonPropertyName("to_location")]
        public DeliveryOrderLocation ToLocation { get; set; }

        /// <summary>
        /// Дополнительные услуги (подробнее см. приложение 3).
        /// </summary>
        [JsonPropertyName("services")]
        public List<AdditionalServiceInfo> Services { get; set; }

        /// <summary>
        /// Список информации по местам (упаковкам).
        /// </summary>
        [JsonPropertyName("packages")]
        public List<DeliveryOrderPackage> Packages { get; set; }

        /// <summary>
        /// Проблемы доставки, с которыми столкнулся курьер при доставке заказа "до двери".
        /// </summary>
        [JsonPropertyName("delivery_problem")]
        public List<DeliveryProblem>? DeliveryProblem { get; set; }

        /// <summary>
        /// Информация о вручении.
        /// </summary>
        [JsonPropertyName("delivery_detail")]
        public DeliveryDetail? DeliveryDetail { get; set; }

        /// <summary>
        /// Признак того, что по заказу была получена информация о переводе наложенного платежа интернет-магазину.
        /// </summary>
        [JsonPropertyName("transacted_payment")]
        public bool? TransactedPayment { get; set; }

        /// <summary>
        /// Список статусов по заказу, отсортированных по дате и времени.
        /// </summary>
        [JsonPropertyName("statuses")]
        public List<DeliveryOrderStatus> Statuses { get; set; }

        /// <summary>
        /// Информация о прозвонах получателя.
        /// </summary>
        [JsonPropertyName("calls")]
        public CallInfo Calls { get; set; }

        /// <summary>
        /// Плановая дата доставки.
        /// </summary>
        [JsonPropertyName("planned_delivery_date")]
        public DateTime? PlannedDeliveryDate { get; set; }

        /// <summary>
        /// Срок бесплатного хранения заказа на складе.
        /// </summary>
        [JsonPropertyName("keep_free_until")]
        public DateTime? KeepFreeUntil { get; set; }

        /// <summary>
        /// Информация о транспорте для сопроводительной накладной на товар (СНТ).
        /// </summary>
        [JsonPropertyName("accompanying_waybill")]
        public AccompanyingWaybill? AccompanyingWaybill { get; set; }
    }
}
