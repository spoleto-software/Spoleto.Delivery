using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<OrderStatus>))]
    public enum OrderStatus
    {
        /// <summary>
        /// Принят
        /// </summary>
        /// <remarks>Заказ создан в информационной системе СДЭК, но требуются дополнительные валидации</remarks>
        [JsonEnumValue("ACCEPTED")]
        [Description("Принят")]
        Accepted,

        /// <summary>
        /// Создан
        /// </summary>
        /// <remarks>Заказ создан в информационной системе СДЭК и прошел необходимые валидации</remarks>
        [JsonEnumValue("CREATED")]
        [Description("Создан")]
        Created,

        /// <summary>
        /// Принят на склад отправителя
        /// </summary>
        /// <remarks>Оформлен приход на склад СДЭК в городе-отправителе.</remarks>
        [JsonEnumValue("RECEIVED_AT_SHIPMENT_WAREHOUSE")]
        [Description("Принят на склад отправителя")]
        ReceivedAtShipmentWarehouse,

        /// <summary>
        /// Выдан на отправку в г. отправителе
        /// </summary>
        /// <remarks>Оформлен расход со склада СДЭК в городе-отправителе. Груз подготовлен к отправке (консолидирован с другими посылками)</remarks>
        [JsonEnumValue("READY_TO_SHIP_AT_SENDING_OFFICE")]
        [Description("Выдан на отправку в г. отправителе")]
        ReadyToShipAtSendingOffice,

        /// <summary>
        /// Выдан на отправку в г. отправителе
        /// </summary>
        /// <remarks>Оформлен расход со склада СДЭК в городе-отправителе. Груз подготовлен к отправке (консолидирован с другими посылками)</remarks>
        [JsonEnumValue("READY_FOR_SHIPMENT_IN_TRANSIT_CITY")]
        [Description("Выдан на отправку в г. отправителе")]
        ReadyForShipmentAtTransitCity,

        /// <summary>
        /// Готов к отправке в г. отправителе
        /// </summary>
        /// <remarks>Оформлен расход со склада СДЭК в городе отправителя. Груз подготовлен к отправке (консолидирован с другими заказами)</remarks>
        [JsonEnumValue("READY_FOR_SHIPMENT_IN_SENDER_CITY")]
        [Description("Готов к отправке в г. отправителе")]
        ReadyForShipmentInSenderCity,

        /// <summary>
        /// Возвращен на склад отправителя
        /// </summary>
        /// <remarks>Повторно оформлен приход в городе-отправителе (не удалось передать перевозчику по какой-либо причине). Примечание: этот статус не означает возврат груза отправителю.</remarks>
        [JsonEnumValue("RETURNED_TO_SENDER_CITY_WAREHOUSE")]
        [Description("Возвращен на склад отправителя")]
        ReturnedToSenderCityWarehouse,

        /// <summary>
        /// Сдан перевозчику в г. отправителе
        /// </summary>
        /// <remarks>Зарегистрирована отправка в городе-отправителе. Консолидированный груз передан на доставку (в аэропорт/загружен машину)</remarks>
        [JsonEnumValue("TAKEN_BY_TRANSPORTER_FROM_SENDER_CITY")]
        [Description("Сдан перевозчику в г. отправителе")]
        TakenByTransporterFromSenderCity,

        /// <summary>
        /// Отправлен в г. транзит
        /// </summary>
        /// <remarks>Зарегистрирована отправка в город-транзит. Проставлены дата и время отправления у перевозчика</remarks>
        [JsonEnumValue("SENT_TO_TRANSIT_CITY")]
        [Description("Отправлен в г. транзит")]
        SentToTransitCity,

        /// <summary>
        /// Встречен в г. транзите
        /// </summary>
        /// <remarks>Зарегистрирована встреча в городе-транзите</remarks>
        [JsonEnumValue("ACCEPTED_IN_TRANSIT_CITY")]
        [Description("Встречен в г. транзите")]
        AcceptedInTransitCity,

        /// <summary>
        /// Принят на склад транзита
        /// </summary>
        /// <remarks>Оформлен приход в городе-транзите</remarks>
        [JsonEnumValue("ACCEPTED_AT_TRANSIT_WAREHOUSE")]
        [Description("Принят на склад транзита")]
        AcceptedAtTransitWarehouse,

        /// <summary>
        /// Возвращен на склад транзита
        /// </summary>
        /// <remarks>Повторно оформлен приход в городе-транзите (груз возвращен на склад). Примечание: этот статус не означает возврат груза отправителю.</remarks>
        [JsonEnumValue("RETURNED_TO_TRANSIT_WAREHOUSE")]
        [Description("Возвращен на склад транзита")]
        ReturnedToTransitWarehouse,

        /// <summary>
        /// Выдан на отправку в г. транзите
        /// </summary>
        /// <remarks>Оформлен расход в городе-транзите</remarks>
        [JsonEnumValue("READY_TO_SHIP_IN_TRANSIT_OFFICE")]
        [Description("Выдан на отправку в г. транзите")]
        ReadyToShipInTransitOffice,

        /// <summary>
        /// Сдан перевозчику в г. транзите
        /// </summary>
        /// <remarks>Зарегистрирована отправка у перевозчика в городе-транзите</remarks>
        [JsonEnumValue("TAKEN_BY_TRANSPORTER_FROM_TRANSIT_CITY")]
        [Description("Сдан перевозчику в г. транзите")]
        TakenByTransporterFromTransitCity,

        /// <summary>
        /// Отправлен в г. отправитель
        /// </summary>
        /// <remarks>Зарегистрирована отправка в город-отправитель, груз в пути</remarks>
        [JsonEnumValue("SENT_TO_SENDER_CITY")]
        [Description("Отправлен в г. отправитель")]
        SentToSenderCity,

        /// <summary>
        /// Отправлен в г. получатель
        /// </summary>
        /// <remarks>Зарегистрирована отправка в город-получатель, груз в пути</remarks>
        [JsonEnumValue("SENT_TO_RECIPIENT_CITY")]
        [Description("Отправлен в г. получатель")]
        SentToRecipientCity,

        /// <summary>
        /// Встречен в г. отправителе
        /// </summary>
        /// <remarks>Зарегистрирована встреча груза в городе-отправителе</remarks>
        [JsonEnumValue("ACCEPTED_IN_SENDER_CITY")]
        [Description("Встречен в г. отправителе")]
        AcceptedInSenderCity,

        /// <summary>
        /// Встречен в г. получателе
        /// </summary>
        /// <remarks>Зарегистрирована встреча груза в городе-получателе</remarks>
        [JsonEnumValue("ACCEPTED_IN_RECIPIENT_CITY")]
        [Description("Встречен в г. получателе")]
        AcceptedInRecipientCity,

        /// <summary>
        /// Принят на склад доставки
        /// </summary>
        /// <remarks>Оформлен приход на склад города-получателя, ожидает доставки до двери</remarks>
        [JsonEnumValue("ACCEPTED_AT_RECIPIENT_CITY_WAREHOUSE")]
        [Description("Принят на склад доставки")]
        AcceptedAtRecipientCityWarehouse,

        /// <summary>
        /// Принят на склад до востребования
        /// </summary>
        /// <remarks>Оформлен приход на склад города-получателя. Доставка до склада, посылка ожидает забора клиентом - покупателем ИМ</remarks>
        [JsonEnumValue("ACCEPTED_AT_PICK_UP_POINT")]
        [Description("Принят на склад до востребования")]
        AcceptedAtPickUpPoint,

        /// <summary>
        /// Выдан на доставку
        /// </summary>
        /// <remarks>Добавлен в курьерскую карту, выдан курьеру на доставку</remarks>
        [JsonEnumValue("TAKEN_BY_COURIER")]
        [Description("Выдан на доставку")]
        TakenByCourier,

        /// <summary>
        /// Возвращен на склад доставки
        /// </summary>
        /// <remarks>Оформлен повторный приход на склад в городе-получателе. Доставка не удалась по какой-либо причине, ожидается очередная попытка доставки. Примечание: этот статус не означает возврат груза отправителю.</remarks>
        [JsonEnumValue("RETURNED_TO_RECIPIENT_CITY_WAREHOUSE")]
        [Description("Возвращен на склад доставки")]
        ReturnedToRecipientCityWarehouse,

        /// <summary>
        /// Вручен
        /// </summary>
        /// <remarks>Успешно доставлен и вручен адресату (конечный статус).</remarks>
        [JsonEnumValue("DELIVERED")]
        [Description("Вручен")]
        Delivered,

        /// <summary>
        /// Не вручен
        /// </summary>
        /// <remarks>Покупатель отказался от покупки, возврат в ИМ (конечный статус).</remarks>
        [JsonEnumValue("NOT_DELIVERED")]
        [Description("Не вручен")]
        NotDelivered,

        /// <summary>
        /// Некорректный заказ
        /// </summary>
        /// <remarks>Заказ содержит некорректные данные</remarks>
        [JsonEnumValue("INVALID")]
        [Description("Некорректный заказ")]
        Invalid,

        /// <summary>
        /// Таможенное оформление в стране отправления
        /// </summary>
        /// <remarks>
        /// В процессе таможенного оформления в стране отправителя (для международных заказов).
        /// </remarks>
        [JsonEnumValue("IN_CUSTOMS_INTERNATIONAL")]
        [Description("Таможенное оформление в стране отправления")]
        InCustomsInternational,

        /// <summary>
        /// Отправлено в страну назначения
        /// </summary>
        /// <remarks>
        /// Отправлен в страну назначения, заказ в пути (для международных заказов).
        /// </remarks>
        [JsonEnumValue("SHIPPED_TO_DESTINATION")]
        [Description("Отправлено в страну назначения")]
        ShippedToDestination,

        /// <summary>
        /// Передано транзитному перевозчику
        /// </summary>
        /// <remarks>
        /// Передан транзитному перевозчику для доставки в страну назначения (для международных заказов).
        /// </remarks>
        [JsonEnumValue("PASSED_TO_TRANSIT_CARRIER")]
        [Description("Передано транзитному перевозчику")]
        PassedToTransitCarrier,

        /// <summary>
        /// Таможенное оформление в стране назначения
        /// </summary>
        /// <remarks>
        /// В процессе таможенного оформления в стране назначения (для международных заказов).
        /// </remarks>
        [JsonEnumValue("IN_CUSTOMS_LOCAL")]
        [Description("Таможенное оформление в стране назначения")]
        InCustomsLocal,

        /// <summary>
        /// Таможенное оформление завершено
        /// </summary>
        /// <remarks>
        /// Завершено таможенное оформление заказа (для международных заказов).
        /// </remarks>
        [JsonEnumValue("CUSTOMS_COMPLETE")]
        [Description("Таможенное оформление завершено")]
        CustomsComplete,

        /// <summary>
        /// Заложен в постамат
        /// </summary>
        /// <remarks>
        /// Заложен в постамат, заказ ожидает забора клиентом - покупателем ИМ.
        /// </remarks>
        [JsonEnumValue("POSTOMAT_POSTED")]
        [Description("Заложен в постамат")]
        PostomatPosted,

        /// <summary>
        /// Изъят из постамата курьером
        /// </summary>
        /// <remarks>
        /// Истек срок хранения заказа в постамате, возврат в ИМ.
        /// </remarks>
        [JsonEnumValue("POSTOMAT_SEIZED")]
        [Description("Изъят из постамата курьером")]
        PostomatSeized,

        /// <summary>
        /// Изъят из постамата клиентом
        /// </summary>
        /// <remarks>
        /// Успешно изъят из постамата клиентом - покупателем ИМ.
        /// </remarks>
        [JsonEnumValue("POSTOMAT_RECEIVED")]
        [Description("Изъят из постамата клиентом")]
        PostomatReceived
    }
}
