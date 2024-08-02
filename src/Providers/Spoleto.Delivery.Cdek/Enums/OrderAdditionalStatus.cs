using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Дополнительный статус заказа.
    /// </summary>
    [JsonConverter(typeof(JsonIntEnumConverter<OrderAdditionalStatus>))]
    public enum OrderAdditionalStatus
    {
        /// <summary>
        /// Возврат, неверный адрес
        /// </summary>
        [Description("Возврат, неверный адрес")]
        WrongAddress = 1,

        /// <summary>
        /// Возврат, не дозвонились
        /// </summary>
        [Description("Возврат, не дозвонились")]
        NoAnswer = 2,

        /// <summary>
        /// Возврат, адресат не проживает
        /// </summary>
        [Description("Возврат, адресат не проживает")]
        AddresseeNotResiding = 3,

        /// <summary>
        /// Возврат, не должен выполняться: вес отличается от заявленного более, чем на X г.
        /// </summary>
        [Description("Возврат, не должен выполняться: вес отличается от заявленного более, чем на X г.")]
        WeightMismatch = 4,

        /// <summary>
        /// Возврат, не должен выполняться: фактически нет отправления (на бумаге есть)
        /// </summary>
        [Description("Возврат, не должен выполняться: фактически нет отправления (на бумаге есть)")]
        NoActualShipment = 5,

        /// <summary>
        /// Возврат, не должен выполняться: дубль номера заказа в одном акте приема-передачи
        /// </summary>
        [Description("Возврат, не должен выполняться: дубль номера заказа в одном акте приема-передачи")]
        DuplicateOrderNumber = 6,

        /// <summary>
        /// Возврат, не должен выполняться: не доставляем в данный город/регион
        /// </summary>
        [Description("Возврат, не должен выполняться: не доставляем в данный город/регион")]
        UndeliverableRegion = 7,

        /// <summary>
        /// Возврат, повреждение упаковки, при приемке от отправителя
        /// </summary>
        [Description("Возврат, повреждение упаковки, при приемке от отправителя")]
        PackageDamageFromSender = 8,

        /// <summary>
        /// Возврат, повреждение упаковки, у перевозчика
        /// </summary>
        [Description("Возврат, повреждение упаковки, у перевозчика")]
        PackageDamageFromCarrier = 9,

        /// <summary>
        /// Возврат, повреждение упаковки, на нашем складе/доставке у курьера
        /// </summary>
        [Description("Возврат, повреждение упаковки, на нашем складе/доставке у курьера")]
        PackageDamageOnSite = 10,

        /// <summary>
        /// Возврат, отказ от получения: Без объяснения
        /// </summary>
        [Description("Возврат, отказ от получения: Без объяснения")]
        RefusalNoExplanation = 11,

        /// <summary>
        /// Возврат, отказ от получения: Претензия к качеству товара
        /// </summary>
        [Description("Возврат, отказ от получения: Претензия к качеству товара")]
        ReturnDueToProductQualityComplaint = 12,

        /// <summary>
        /// Возврат, отказ от получения: Недовложение
        /// </summary>
        [Description("Возврат, отказ от получения: Недовложение")]
        ReturnDueToShortShipment = 13,

        /// <summary>
        /// Возврат, отказ от получения: Пересорт
        /// </summary>
        [Description("Возврат, отказ от получения: Пересорт")]
        ReturnDueToWrongItem = 14,

        /// <summary>
        /// Возврат, отказ от получения: Не устроили сроки
        /// </summary>
        [Description("Возврат, отказ от получения: Не устроили сроки")]
        ReturnDueToUnsuitableTerms = 15,

        /// <summary>
        /// Возврат, отказ от получения: Уже купил
        /// </summary>
        [Description("Возврат, отказ от получения: Уже купил")]
        ReturnDueToAlreadyPurchased = 16,

        /// <summary>
        /// Возврат, отказ от получения: Передумал
        /// </summary>
        [Description("Возврат, отказ от получения: Передумал")]
        ReturnDueToChangeOfMind = 17,

        /// <summary>
        /// Возврат, отказ от получения: Ошибка оформления
        /// </summary>
        [Description("Возврат, отказ от получения: Ошибка оформления")]
        ReturnDueToOrderError = 18,

        /// <summary>
        /// Возврат, отказ от получения: Повреждение упаковки, у получателя
        /// </summary>
        [Description("Возврат, отказ от получения: Повреждение упаковки, у получателя")]
        ReturnDueToPackageDamage = 19,

        /// <summary>
        /// Частичная доставка
        /// </summary>
        [Description("Частичная доставка")]
        PartialDelivery = 20,

        /// <summary>
        /// Возврат, отказ от получения: Нет денег
        /// </summary>
        [Description("Возврат, отказ от получения: Нет денег")]
        ReturnDueToLackOfFunds = 21,

        /// <summary>
        /// Возврат, отказ от получения: Товар не подошел/не понравился
        /// </summary>
        [Description("Возврат, отказ от получения: Товар не подошел/не понравился")]
        ReturnDueToUnsatisfactoryProduct = 22,

        /// <summary>
        /// Возврат, истек срок хранения
        /// </summary>
        [Description("Возврат, истек срок хранения")]
        ReturnDueToStorageTimeExpired = 23,

        /// <summary>
        /// Возврат, не прошел таможню
        /// </summary>
        [Description("Возврат, не прошел таможню")]
        ReturnDueToCustomsFailure = 24,

        /// <summary>
        /// Возврат, не должен выполняться: является коммерческим грузом
        /// </summary>
        [Description("Возврат, не должен выполняться: является коммерческим грузом")]
        ReturnDueToCommercialCargo = 25,

        /// <summary>
        /// Утерян
        /// </summary>
        [Description("Утерян")]
        Lost = 26,

        /// <summary>
        /// Не востребован, утилизация
        /// </summary>
        [Description("Не востребован, утилизация")]
        UnclaimedDisposal = 27,

        /// <summary>
        /// Возврат, по запросу отправителя
        /// </summary>
        [Description("Возврат, по запросу отправителя")]
        ReturnAtSenderRequest = 31,

        /// <summary>
        /// Возврат, по запросу плательщика
        /// </summary>
        [Description("Возврат, по запросу плательщика")]
        ReturnAtPayerRequest = 32,

        /// <summary>
        /// Возврат, СНТ не получено
        /// </summary>
        [Description("Возврат, СНТ не получено")]
        ReturnDueToSNTNotReceived = 33
    }
}
