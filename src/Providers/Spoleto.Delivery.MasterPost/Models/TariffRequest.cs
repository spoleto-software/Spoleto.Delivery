﻿using System.Text.Json.Serialization;
using Spoleto.Delivery.Providers.MasterPost.Converters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Запрос на расчет стоимости тарифа.
    /// </summary>
    public record TariffRequest
    {
        /// <summary>
        /// Клиентский Номер (ID).
        /// </summary>
        [JsonPropertyName("DN_IKN")]
        public string IndividualClientNumber { get; set; }

        /// <summary>
        /// Режим Доставки.
        /// </summary>
        [JsonPropertyName("DN_MODE")]
        public string DeliveryMode { get; set; }

        /// <summary>
        /// Прямая доставка.
        /// </summary>
        /// <remarks>
        /// Если передать значение true, то доставка может быть осуществлена день в день напрямую от отправителя получателю, минуя склад Мастерпост.
        /// </remarks>
        [JsonPropertyName("STRAIGHT_DELIVERY")]
        public bool IsStraightDelivery { get; set; }

        /// <summary>
        /// Код Адреса Отправителя.
        /// </summary>
        /// <remarks>
        /// Если в STRAIGHT_DELIVERY передано значение true, то ожидается список адресов в этом теге.<br/>
        /// Если этот тег заполнен, то тег <see cref="SenderAddress"/> (DN_SEND_STR) игнорируется.<br/>
        /// Обязательно должно быть заполнен либо этот тег, либо тег <see cref="SenderCity"/> (DN_SEND_CITY).
        /// </remarks>
        [JsonPropertyName("DN_SEND_ADR_CODE")]
        [JsonConverter(typeof(JsonSenderAddressCodeConverter))]
        public List<string> SenderAddressCodes { get; set; } = [];

        ///// <summary>
        ///// Адрес Отправителя.
        ///// </summary>
        //[JsonPropertyName("DN_SEND_STR")]
        //public string SenderAddress { get; set; } = string.Empty;

        /// <summary>
        /// Город Отправителя.
        /// </summary>
        /// <remarks>
        /// УИД ФИАС, либо код КЛАДР.<br/>
        /// Обязательно должно быть заполнен либо этот тег, либо тег <see cref="SenderAddressCodes"/> (DN_SEND_ADR_CODE).<br/><br/>
        /// В тарифной сетке присутствуют города. Вне зависимости от улицы города.
        /// Поэтому, обычно достаточно указать город отправителя, город получателя, параметры тарифа, чтобы получить стоимость тарифа.
        /// </remarks>
        [JsonPropertyName("DN_SEND_CITY")]
        public string SenderCity { get; set; } = string.Empty;

        ///// <summary>
        ///// Адрес Получателя.
        ///// </summary>
        //[JsonPropertyName("DN_REC_STR")]
        //public string? RecipientAddress { get; set; }

        /// <summary>
        /// Город Получателя.
        /// </summary>
        /// <remarks>
        /// УИД ФИАС, либо код КЛАДР.<br/><br/>
        /// В тарифной сетке присутствуют города. Вне зависимости от улицы города.
        /// Поэтому, обычно достаточно указать город отправителя, город получателя, параметры тарифа, чтобы получить стоимость тарифа.
        /// </remarks>
        [JsonPropertyName("DN_REC_CITY")]
        public string RecipientCity { get; set; } = string.Empty;

        /// <summary>
        /// Согласованная дата доставки.
        /// </summary>
        [JsonPropertyName("DN_PLAN_DELDATE")]
        public DateTime PlannedDeliveryDate { get; set; }

        /// <summary>
        /// Согласованный временной интервал доставки.
        /// </summary>
        /// <remarks>
        /// 10:00-14:00
        /// </remarks>
        [JsonPropertyName("DN_PLAN_DELTIME")]
        public string PlannedDeliveryTimeInterval { get; set; } = string.Empty;

        /// <summary>
        /// Оценочная Стоимость.
        /// </summary>
        /// <remarks>
        /// Передаем если выбрана соответствующая услуга.<br/>
        /// Если ART_EST_PRICE (оценочная стоимость в артикулах), то это поле будет пересчитано как сумма оценочной стоимости по всем строкам артикулов.
        /// </remarks>
        [JsonPropertyName("DN_COST")]
        public decimal? EstimatedCost { get; set; }

        /// <summary>
        /// SMS Оповещение Отправителя.
        /// </summary>
        /// <remarks>
        /// Формат: + код страны XXX XXX XX XX.<br/>
        /// Номер телефона отправителя, если выбрана услуга.
        /// </remarks>
        [JsonPropertyName("DN_SEND_SMS")]
        public string SenderSms { get; set; }

        /// <summary>
        /// SMS Информирование Получателя
        /// </summary>
        /// <remarks>
        /// Формат: + код страны XXX XXX XX XX.<br/>
        /// Номер телефона получателя, если выбрана услуга.
        /// </remarks>
        [JsonPropertyName("DN_REC_SMS")]
        public string RecipientSms { get; set; }

        /// <summary>
        /// Плановая Дата Сбора.
        /// </summary>
        /// <remarks>
        /// Тариф рассчитывается на дату из этого тега.<br/>
        /// Если тег не заполнен, тариф рассчитывается на текущую дату.
        /// </remarks>
        [JsonPropertyName("DN_PLAN_DATE")]
        public DateTime PlannedPickupnDate { get; set; }

        /// <summary>
        /// Дополнительные Услуги.
        /// </summary>
        [JsonPropertyName("ADDSERV")]
        public List<AdditionalServiceBase> AdditionalServices { get; set; }

        /// <summary>
        /// Грузо-места.
        /// </summary>
        [JsonPropertyName("PLACE")]
        public List<CargoPlaceBase> CargoPlaces { get; set; }

        /// <summary>
        /// Оценочная Стоимость
        /// </summary>
        [JsonPropertyName("ART")]
        public List<CargoArticle> CargoArticles { get; set; }
    }
}
