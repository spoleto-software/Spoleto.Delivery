using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Проблема доставки.
    /// </summary>
    [JsonConverter(typeof(JsonIntEnumConverter<DeliveryProblemType>))]
    public enum DeliveryProblemType
    {
        /// <summary>
        /// Телефон неверный
        /// </summary>
        [Description("Телефон неверный")]
        IncorrectPhoneNumber = 1,

        /// <summary>
        /// Груз не готов
        /// </summary>
        [Description("Груз не готов")]
        CargoNotReady = 9,

        /// <summary>
        /// Отказ от оплаты
        /// </summary>
        [Description("Отказ от оплаты")]
        RefusalToPay = 11,

        /// <summary>
        /// Контактное лицо отсутствует
        /// </summary>
        [Description("Контактное лицо отсутствует")]
        ContactPersonAbsent = 13,

        /// <summary>
        /// Организация не работает
        /// </summary>
        [Description("Организация не работает")]
        OrganizationNotWorking = 17,

        /// <summary>
        /// Смена адреса
        /// </summary>
        [Description("Смена адреса")]
        AddressChange = 19,

        /// <summary>
        /// Не успеваю
        /// </summary>
        [Description("Не успеваю")]
        NotInTime = 35,

        /// <summary>
        /// Самозабор
        /// </summary>
        [Description("Самозабор")]
        SelfPickup = 36,

        /// <summary>
        /// Постамат переполнен
        /// </summary>
        [Description("Постамат переполнен")]
        LockerOverfilled = 37,

        /// <summary>
        /// Постамат не работает
        /// </summary>
        [Description("Постамат не работает")]
        LockerNotWorking = 38,

        /// <summary>
        /// Груз не влез в ячейку постамата
        /// </summary>
        [Description("Груз не влез в ячейку постамата")]
        CargoWillNotFitInLocker = 39,

        /// <summary>
        /// Отказ от получения
        /// </summary>
        [Description("Отказ от получения")]
        RefusalToReceive = 40,

        /// <summary>
        /// Отказ от заявки
        /// </summary>
        [Description("Отказ от заявки")]
        RefusalOfApplication = 41,

        /// <summary>
        /// Требуется пропуск
        /// </summary>
        [Description("Требуется пропуск")]
        PermitRequired = 42,

        /// <summary>
        /// Платный въезд
        /// </summary>
        [Description("Платный въезд")]
        PaidEntry = 43,

        /// <summary>
        /// Закрытая территория
        /// </summary>
        [Description("Закрытая территория")]
        ClosedTerritory = 44,

        /// <summary>
        /// Нет документа удостоверяющего личность
        /// </summary>
        [Description("Нет документа удостоверяющего личность")]
        NoIdentityDocument = 45,

        /// <summary>
        /// Смена города
        /// </summary>
        [Description("Смена города")]
        ChangeOfCity = 46,

        /// <summary>
        /// Адрес не существует
        /// </summary>
        [Description("Адрес не существует")]
        AddressDoesNotExist = 47,

        /// <summary>
        /// Доставка в А/Я
        /// </summary>
        [Description("Доставка в А/Я")]
        DeliveryToPoBox = 48,

        /// <summary>
        /// Опасный груз
        /// </summary>
        [Description("Опасный груз")]
        DangerousCargo = 49,

        /// <summary>
        /// Отказ с адреса
        /// </summary>
        [Description("Отказ с адреса")]
        RefusalFromAddress = 52,

        /// <summary>
        /// Изменение интервала по согласованию с клиентом
        /// </summary>
        [Description("Изменение интервала по согласованию с клиентом")]
        IntervalChangeWithClientAgreement = 53,

        /// <summary>
        /// Постаматное приложение не работает
        /// </summary>
        [Description("Постаматное приложение не работает")]
        LockerApplicationNotWorking = 54,

        /// <summary>
        /// Груз не найден
        /// </summary>
        [Description("Груз не найден")]
        CargoNotFound = 55,

        /// <summary>
        /// Передача на ПВЗ
        /// </summary>
        [Description("Передача на ПВЗ")]
        TransferToPickUpPoint = 56,

        /// <summary>
        /// Не могу доставить на ПВЗ
        /// </summary>
        [Description("Не могу доставить на ПВЗ")]
        CannotDeliverToPickUpPoint = 57
    }
}
