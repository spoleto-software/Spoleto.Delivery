using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Ставка НДС.
    /// </summary>
    [JsonConverter(typeof(JsonEnumIntValueConverter<VatRate>))]//todo???
    public enum VatRate
    {
        /// <summary>
        /// Без НДС.
        /// </summary>
        [JsonEnumIntValue]
        WO_VAT = -1,

        /// <summary>
        /// Ставка НДС 0%.
        /// </summary>
        [JsonEnumIntValue(0)]
        NO_VAT = 0,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [JsonEnumIntValue(10)]
        VAT_10 = 10,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [JsonEnumIntValue(12)]
        VAT_12 = 12,

        /// <summary>
        /// Ставка НДС 20%.
        /// </summary>
        [JsonEnumIntValue(20)]
        VAT_20 = 20
    }
}
