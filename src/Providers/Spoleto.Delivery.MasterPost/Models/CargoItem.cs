using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Товар.
    /// </summary>
    public record CargoItem
    {
        /// <summary>
        /// Артикул
        /// </summary>
        [JsonPropertyName("ART_NUM")]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Номенклатура
        /// </summary>
        [JsonPropertyName("ART_NAME")]
        public string ArticleName { get; set; }

        /// <summary>
        /// Код маркировки
        /// </summary>
        [JsonPropertyName("ART_MARK")]
        public string ArticleMarkingCode { get; set; }

        /// <summary>
        /// Криптохвост
        /// </summary>
        [JsonPropertyName("ART_MARK_TAIL")]
        public string ArticleMarkingTail { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [JsonPropertyName("ART_QTY")]
        public decimal ArticleQuantity { get; set; }

        /// <summary>
        /// Ставка НДС
        /// </summary>
        /// <remarks>
        /// Система ожидает одно из 4 значений: 20, 10, 0 либо WO_VAT.<br/>
        /// Первые 3 значения можно передать как число, либо как строку. Они соответствуют процентам НДС.<br/>
        /// Последнее значение соответствует ставке "Без НДС".<br/>
        /// Если передать пустую строку, система подставит значение 20.<br/>
        /// Если передать любое другое значение метод вернет ошибку 400 - "Wrong ART_VAT_RATE ПереданноеЗначениеТега".
        /// </remarks>
        [JsonPropertyName("ART_VAT_RATE")]
        public VatRate ArticleVatRate { get; set; } = VatRate.VAT_20;

        /// <summary>
        /// Стоимость без НДС
        /// </summary>
        /// <remarks>
        /// Если не передать это значение, оно будет расчитано автоматически
        /// </remarks>
        [JsonPropertyName("ART_PRICE_WO_VAT")]
        public decimal ArticlePriceWithoutVat { get; set; }

        /// <summary>
        /// Стоимость включая НДС
        /// </summary>
        /// <remarks>
        /// Может принимать нулевое начение
        /// </remarks>
        [JsonPropertyName("ART_PRICE")]
        public decimal ArticlePriceWithVat { get; set; }

        /// <summary>
        /// Оценочная Стоимость
        /// </summary>
        /// <remarks>
        /// Может принимать нулевое начение
        /// </remarks>
        [JsonPropertyName("ART_EST_PRICE")]
        public decimal ArticleEstimatedPrice { get; set; }
    }
}
