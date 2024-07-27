using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.MasterPost.Converters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Created Masterpost delivery order.
    /// </summary>
    public record DeliveryOrder
    {
        /// <summary>
        /// Номер ДН.
        /// </summary>
        [JsonPropertyName("DN_NUM")]
        public string Number { get; set; }

        /// <summary>
        /// Дата ДН.
        /// </summary>
        /// <remarks>Формат: 2018-08-03T13:20:00.</remarks>
        [JsonPropertyName("DN_DATE")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата приема ДН.
        /// </summary>
        /// <remarks>Формат: 2018-08-03T13:20:00.</remarks>
        [JsonPropertyName("DN_GR_DATE")]
        public DateTime GrDate { get; set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        [JsonPropertyName("DN_STATUS_CUR")]
        public string CurrentStatus { get; set; }

        /// <summary>
        /// Дата статуса заявки на сбор ДН.
        /// </summary>
        /// <remarks>Поле обязательно, только если создана заявка.</remarks>
        [JsonPropertyName("DN_REQ_STATUS_DATE")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? RequestStatusDate { get; set; }

        /// <summary>
        /// Текущий статус заявки на сбор ДН.
        /// </summary>
        /// <remarks>Поле обязательно, только если создана заявка.</remarks>
        [JsonPropertyName("DN_REQ_STATUS")]
        public string RequestStatus { get; set; }

        /// <summary>
        /// Комментарий к текущему статусу заявки на сбор ДН.
        /// </summary>
        [JsonPropertyName("DN_REQ_STATUS_COMM")]
        public string RequestStatusComment { get; set; }

        /// <summary>
        /// Клиентский номер (Код).
        /// </summary>
        [JsonPropertyName("DN_IKN")]
        public string IndividualClientNumber { get; set; }

        /// <summary>
        /// Режим доставки.
        /// </summary>
        [JsonPropertyName("DN_MODE")]
        public string DeliveryMode { get; set; }

        /// <summary>
        /// Адрес отправителя в свободной форме.
        /// </summary>
        [JsonPropertyName("DN_SEND_ADR")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Адрес отправителя код.
        /// </summary>
        [JsonPropertyName("DN_SEND_ADR_CODE")]
        public string SenderAddressCode { get; set; }

        /// <summary>
        /// Город отправителя код ФИАС.
        /// </summary>
        /// <remarks>Пример: 93b3df57-4c89-44df-ac42-96f05e9cd3b9.</remarks>
        [JsonPropertyName("DN_SEND_CITY")]
        [JsonConverter(typeof(JsonGuidConverter))]
        public Guid? SenderCityFiasGuid { get; set; }

        /// <summary>
        /// Город отправителя код КЛАДР.
        /// </summary>
        /// <remarks>Пример: 0200000100000.</remarks>
        [JsonPropertyName("DN_SEND_CITY_KLADR")]
        public string SenderCityKladrCode { get; set; }

        /// <summary>
        /// Организация отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_COMP")]
        public string SenderCompany { get; set; }

        /// <summary>
        /// Улица отправителя код ФИАС.
        /// </summary>
        [JsonPropertyName("DN_SEND_STR")]
        [JsonConverter(typeof(JsonGuidConverter))]
        public Guid? SenderStreetFiasGuid { get; set; }

        /// <summary>
        /// Улица отправителя код КЛАДР.
        /// </summary>
        /// <remarks>Пример: 000006321.</remarks>
        [JsonPropertyName("DN_SEND_STR_KLADR")]
        public string SenderStreetKladrCode { get; set; }

        /// <summary>
        /// Дом Отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_HOME")]
        public int SenderHouseNumber { get; set; }

        /// <summary>
        /// Дополнительная информация отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_INFO")]
        public string? SenderAdditionalInfo { get; set; }

        /// <summary>
        /// Контактное лицо отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_CONT")]
        public string SenderContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_PHONE")]
        public string SenderContactPhone { get; set; }

        /// <summary>
        /// Адрес получателя в свободной форме.
        /// </summary>
        [JsonPropertyName("DN_REC_ADR")]
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// Город получателя код ФИАС.
        /// </summary>
        [JsonPropertyName("DN_REC_CITY")]
        [JsonConverter(typeof(JsonGuidConverter))]
        public Guid? ReceiverCityFiasGuid { get; set; }

        /// <summary>
        /// Город получателя код КЛАДР.
        /// </summary>
        /// <remarks>Пример: 7800000003900.</remarks>
        [JsonPropertyName("DN_REC_CITY_KLADR")]
        public string ReceiverCityKladrCode { get; set; }

        /// <summary>
        /// Организация получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_COMP")]
        public string ReceiverCompany { get; set; }

        /// <summary>
        /// Улица получателя код ФИАС.
        /// </summary>
        [JsonPropertyName("DN_REC_STR")]
        [JsonConverter(typeof(JsonGuidConverter))]
        public Guid? ReceiverStreetFiasGuid { get; set; }

        /// <summary>
        /// Улица получателя код КЛАДР.
        /// </summary>
        /// <remarks>Пример: 7800000003900.</remarks>
        [JsonPropertyName("DN_REC_STR_KLADR")]
        public string ReceiverStreetKladrCode { get; set; }

        /// <summary>
        /// Дом получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_APT")]
        public int ReceiverHouseNumber { get; set; }

        /// <summary>
        /// Дополнительная информация получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_INFO")]
        public string? ReceiverAdditionalInfo { get; set; }

        /// <summary>
        /// Контактное лицо получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_CONT")]
        public string ReceiverContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_PHONE")]
        public string ReceiverContactPhone { get; set; }

        /// <summary>
        /// Email адрес получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_EMAIL")]
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Согласованная дата доставки.
        /// </summary>
        [JsonPropertyName("DN_PLANDATE")]
        public DateTime? PlannedDeliveryDate { get; set; }

        /// <summary>
        /// Согласованный временной интервал доставки.
        /// </summary>
        /// <remarks>Пример: 10:00-14:00.</remarks>
        [JsonPropertyName("DN_PLANTIME")]
        public string? PlannedDeliveryTime { get; set; }

        /// <summary>
        /// Суммарный вес, кг.
        /// </summary>
        [JsonPropertyName("DN_WEIGHT")]
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// Количество мест.
        /// </summary>
        [JsonPropertyName("DN_PLACE")]
        public int PlaceCount { get; set; }

        /// <summary>
        /// Номер заказа.
        /// </summary>
        /// <remarks>Внутренний номер клиента.</remarks>
        [JsonPropertyName("DN_ORDER")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Оценочная стоимость.
        /// </summary>
        [JsonPropertyName("DN_COST")]
        public decimal? EstimatedCost { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [JsonPropertyName("DN_COMMENT")]
        public string? Comment { get; set; }

        /// <summary>
        /// Способ оплаты.
        /// </summary>
        [JsonPropertyName("DN_PAYMENT")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// До востребования.
        /// </summary>
        [JsonPropertyName("DN_SELFPICK")]
        public bool IsSelfPickup { get; set; }

        /// <summary>
        /// Суммарный объем, м3.
        /// </summary>
        [JsonPropertyName("DN_VOL")]
        public decimal? TotalVolume { get; set; }

        /// <summary>
        /// SMS оповещение отправителя.
        /// </summary>
        [JsonPropertyName("DN_SEND_SMS")]
        public string? SenderSmsNotification { get; set; }

        /// <summary>
        /// SMS информирование получателя.
        /// </summary>
        [JsonPropertyName("DN_REC_SMS")]
        public string? ReceiverSmsNotification { get; set; }

        /// <summary>
        /// Описание вложимого.
        /// </summary>
        [JsonPropertyName("DN_CARGO_DESCR")]
        public string? CargoDescription { get; set; }

        /// <summary>
        /// Сбор при доставке ДН.
        /// </summary>
        [JsonPropertyName("DN_RECIEVE_PACK")]
        public string? ReceivePack { get; set; }

        /// <summary>
        /// Стоимость доставки за заказ.
        /// </summary>
        [JsonPropertyName("DN_DEL_COST")]
        public decimal DeliveryCost { get; set; }

        /// <summary>
        /// Дата и время доставки.
        /// </summary>
        [JsonPropertyName("DN_DELTIME")]
        public DateTime? DeliveryDateTime { get; set; }

        /// <summary>
        /// Номер резерва.
        /// </summary>
        [JsonPropertyName("RESERVE_NUMBER")]
        public string ReserveNumber { get; set; }

        /// <summary>
        /// ДопУслуга
        /// </summary>
        [JsonPropertyName("ADDSERV")]
        public List<AdditionalServiceBase>? AdditionalServices { get; set; }

        /// <summary>
        /// Грузо-места
        /// </summary>
        [JsonPropertyName("PLACE")]
        public List<DeliveryOrderCargoPlace> Places { get; set; }

        /// <summary>
        /// Груз
        /// </summary>
        [JsonPropertyName("ART")]
        public List<DeliveryOrderCargoItem> Items { get; set; }

        /// <summary>
        /// Стоимости услуг доставки.
        /// </summary>
        [JsonPropertyName("RATE")]
        public List<DeliveryOrderRate> Rates { get; set; }

        /// <summary>
        /// Статусы доставки.
        /// </summary>
        [JsonPropertyName("STATUS")]
        public List<DeliveryOrderStatus> Statuses { get; set; }

        /// <summary>
        /// Дополнительные заказы на доставку.
        /// </summary>
        /// <remarks>Например, Доставка упаковки или Доставка по резерву.</remarks>
        [JsonPropertyName("ADDDNS")]
        public List<AdditionalDeliveryOrder> AdditionalDeliveryOrders { get; set; }
    }
}

