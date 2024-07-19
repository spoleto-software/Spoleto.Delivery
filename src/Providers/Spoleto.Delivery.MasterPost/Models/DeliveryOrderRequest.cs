using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Masterpost delivery order request.
    /// </summary>
    public record DeliveryOrderRequest
    {
        /// <summary>
        /// Клиентский Номер (ID)
        /// </summary>
        [JsonPropertyName("DN_IKN")]
        public string IndividualClientNumber { get; set; }

        /// <summary>
        /// Режим Доставки
        /// </summary>
        [JsonPropertyName("DN_MODE")]
        public string DeliveryMode { get; set; }

        /// <summary>
        /// Прямая доставка
        /// </summary>
        /// <remarks>
        /// Если передать значение true, то доставка может быть осуществлена день в день напрямую от отправителя получателю, минуя склад Мастерпост.
        /// </remarks>
        [JsonPropertyName("STRAIGHT_DELIVERY")]
        public bool StraightDelivery { get; set; }

        /// <summary>
        /// Код Адреса Отправителя
        /// </summary>
        /// <remarks>
        /// Если в <see cref="StraightDelivery">STRAIGHT_DELIVERY</see> передано значение true, то ожидается список адресов в этом теге.<br/>
        /// Если этот тег заполнен, то теги <see cref="SenderCompany">DN_SEND_COMP</see>, <see cref="SenderInfo">DN_SEND_INFO</see>, <see cref="SenderCity">DN_SEND_CITY</see>, <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see> игнорируются.<br/>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_ADR_CODE")]
        public string SenderAddressCode { get; set; }

        /// <summary>
        /// Организация Отправителя
        /// </summary>
        /// <remarks>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_COMP")]
        public string SenderCompany { get; set; }

        /// <summary>
        /// Доп Информация Отправителя
        /// </summary>
        [JsonPropertyName("DN_SEND_INFO")]
        public string SenderInfo { get; set; }

        /// <summary>
        /// Город Отправителя
        /// </summary>
        /// <remarks>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_CITY")]
        public string SenderCity { get; set; }

        /// <summary>
        /// Улица Отправителя
        /// </summary>
        /// <remarks>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_STR")]
        public string SenderStreet { get; set; }

        /// <summary>
        /// Дом Отправителя
        /// </summary>
        /// <remarks>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_HOME")]
        public int SenderHome { get; set; }

        /// <summary>
        /// Адрес Отправителя В Свободной Форме
        /// </summary>
        /// <remarks>
        /// Обязательно должно быть заполнено одно из трех: ((<see cref="SenderAddress">DN_SEND_ADR</see> и <see cref="SenderCity">DN_SEND_CITY</see>) или <see cref="SenderAddressCode">DN_SEND_ADR_CODE</see> или (<see cref="SenderCompany">DN_SEND_COMP</see> и <see cref="SenderCity">DN_SEND_CITY</see> и <see cref="SenderStreet">DN_SEND_STR</see> и <see cref="SenderHome">DN_SEND_HOME</see>))
        /// </remarks>
        [JsonPropertyName("DN_SEND_ADR")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Контактное Лицо Отправителя
        /// </summary>
        /// <remarks>
        /// Вместе с этим полем, обязательно должно передаваться не пустое значение поля <see cref="SenderCompany">DN_SEND_COMP</see>
        /// </remarks>
        [JsonPropertyName("DN_SEND_CONT")]
        public string SenderContact { get; set; }

        /// <summary>
        /// Контактный Телефон Отправителя
        /// </summary>
        [JsonPropertyName("DN_SEND_PHONE")]
        public string SenderPhone { get; set; }

        /// <summary>
        /// Код филиала
        /// </summary>
        /// <remarks>
        /// Если заполнено, то остальные поля, связанные с адресом получателя игнорируются
        /// </remarks>
        [JsonPropertyName("DN_REC_BRANCH_CODE")]
        public int RecipientBranchCode { get; set; }

        /// <summary>
        /// Город Получателя
        /// </summary>
        [JsonPropertyName("DN_REC_CITY")]
        public string RecipientCity { get; set; }

        /// <summary>
        /// Улица Получателя
        /// </summary>
        /// <remarks>
        /// Обязательно, если не заполнен адрес в свободной форме
        /// </remarks>
        [JsonPropertyName("DN_REC_STR")]
        public string RecipientStreet { get; set; }

        /// <summary>
        /// Дом Получателя
        /// </summary>
        /// <remarks>
        /// Обязательно, если не заполнен адрес в свободной форме
        /// </remarks>
        [JsonPropertyName("DN_REC_APT")]
        public int RecipientHome { get; set; }

        /// <summary>
        /// Адрес Получателя В Свободной Форме
        /// </summary>
        /// <remarks>
        /// Обязательно, если не заполнен точный адрес
        /// </remarks>
        [JsonPropertyName("DN_REC_ADR")]
        public string RecipientAddress { get; set; }

        /// <summary>
        /// Организация Получателя
        /// </summary>
        /// <remarks>
        /// Обязательно, если не заполнен адрес в свободной форме
        /// </remarks>
        [JsonPropertyName("DN_REC_COMP")]
        public string RecipientCompany { get; set; }

        /// <summary>
        /// Доп Информация Получателя
        /// </summary>
        [JsonPropertyName("DN_REC_INFO")]
        public string RecipientInfo { get; set; }

        /// <summary>
        /// Контактное Лицо Получателя
        /// </summary>
        /// <remarks>
        /// Вместе с этим полем, обязательно должно передаваться не пустое значение поля <see cref="RecipientCompany">DN_REC_COMP</see>
        /// </remarks>
        [JsonPropertyName("DN_REC_CONT")]
        public string RecipientContact { get; set; }

        /// <summary>
        /// Контактный Телефон Получателя
        /// </summary>
        [JsonPropertyName("DN_REC_PHONE")]
        public string RecipientPhone { get; set; }

        /// <summary>
        /// Email адрес Получателя
        /// </summary>
        [JsonPropertyName("DN_REC_MAIL")]
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Согласованная дата доставки.
        /// </summary>
        [JsonPropertyName("DN_PLAN_DELDATE")]
        public DateTime PlanDeliveryDate { get; set; }

        /// <summary>
        /// Согласованный временной интервал доставки.
        /// </summary>
        /// <remarks>
        /// Пример: "10:00-14:00".
        /// </remarks>
        [JsonPropertyName("DN_PLAN_DELTIME")]
        public string PlanDeliveryTime { get; set; } = string.Empty;

        /// <summary>
        /// Номер заказа.
        /// </summary>
        /// <remarks>
        /// Номер накладной клиента.
        /// </remarks>
        [JsonPropertyName("DN_ORDER")]
        public string OrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Оценочная стоимость.
        /// </summary>
        /// <remarks>
        /// Передается, если выбрана соответствующая услуга.
        /// </remarks>
        [JsonPropertyName("DN_COST")]
        public decimal EstimatedCost { get; set; }

        /// <summary>
        /// Комментарий к заказу.
        /// </summary>
        [JsonPropertyName("DN_COMMENT")]
        public string? Comment { get; set; }

        /// <summary>
        /// Способ оплаты
        /// </summary>
        /// <remarks>
        /// Наличными Получатель, Наличными Отправитель, По Договору
        /// </remarks>
        [JsonPropertyName("DN_PAYMENT")]
        [JsonConverter(typeof(JsonEnumValueConverter<PaymentType>))]
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// До Востребования
        /// </summary>
        [JsonPropertyName("DN_SELFPICK")]
        public bool SelfPick { get; set; }

        /// <summary>
        /// SMS Оповещение Отправителя
        /// </summary>
        /// <remarks>
        /// + код страны XXX XXX XX XX<br/>
        /// Номер телефона отправителя, если выбрана услуга
        /// </remarks>
        [JsonPropertyName("DN_SEND_SMS")]
        public string SenderSmsNotification { get; set; }

        /// <summary>
        /// SMS Информирование Получателя
        /// </summary>
        /// <remarks>
        /// + код страны XXX XXX XX XX<br/>
        /// Номер телефона получателя, если выбрана услуга
        /// </remarks>
        [JsonPropertyName("DN_REC_SMS")]
        public string RecipientSmsNotification { get; set; }

        /// <summary>
        /// Описание Вложимого
        /// </summary>
        [JsonPropertyName("DN_CARGO_DESCR")]
        public string CargoDescription { get; set; }

        /// <summary>
        /// Сбор При Доставке ДН
        /// </summary>
        /// <remarks>
        /// XXX-XXX-XXXXXX<br/>
        /// Ссылочный номер ДН
        /// </remarks>
        [JsonPropertyName("DN_RECIEVE_PACK")]
        public string CollectionAtDelivery { get; set; }

        /// <summary>
        /// Плановая Дата Сбора
        /// </summary>
        /// <remarks>
        /// Обязательно, если требуется оформить и вызов курьера
        /// </remarks>
        [JsonPropertyName("DN_PLAN_DATE")]
        public DateTime PlannedCollectionDate { get; set; }

        /// <summary>
        /// ИнтервалВремениСбораС
        /// </summary>
        /// <remarks>
        /// Обязательно, если требуется оформить и вызов курьера
        /// </remarks>
        [JsonPropertyName("DN_PLAN_TIME_FR")]
        public TimeSpan PlannedCollectionTimeFrom { get; set; }

        /// <summary>
        /// ИнтервалВремениСбораПо
        /// </summary>
        /// <remarks>
        /// Обязательно, если требуется оформить и вызов курьера
        /// </remarks>
        [JsonPropertyName("DN_PLAN_TIME_TO")]
        public TimeSpan PlannedCollectionTimeTo { get; set; }

        /// <summary>
        /// Номер резерва
        /// </summary>
        /// <remarks>
        /// Обязательно, если требуется создание доп. ДН "Доставка по резерву"
        /// </remarks>
        [JsonPropertyName("RESERVE_NUMBER")]
        public string ReserveNumber { get; set; }

        /// <summary>
        /// ДопУслуга
        /// </summary>
        [JsonPropertyName("ADDSERV")]
        public List<AdditionalServiceBase> AdditionalServices { get; set; }

        /// <summary>
        /// Грузо-места
        /// </summary>
        [JsonPropertyName("PLACE")]
        public List<CargoPlace> Places { get; set; }

        /// <summary>
        /// Груз
        /// </summary>
        [JsonPropertyName("ART")]
        public List<CargoItem> Items { get; set; }
    }
}
