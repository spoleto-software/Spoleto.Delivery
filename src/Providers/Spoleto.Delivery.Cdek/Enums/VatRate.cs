using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Ставка НДС.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<VatRate>))]//todo???
    public enum VatRate
    {
        /// <summary>
        /// Без НДС.
        /// </summary>
        [JsonEnumValue(null)]
        WO_VAT = -1,

        /// <summary>
        /// Ставка НДС 0%.
        /// </summary>
        [JsonEnumValue("0")]
        NO_VAT = 0,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [JsonEnumValue("10")]
        VAT_10 = 10,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [JsonEnumValue("10")]
        VAT_12 = 12,

        /// <summary>
        /// Ставка НДС 20%.
        /// </summary>
        [JsonEnumValue("20")]
        VAT_20 = 20
    }
}
