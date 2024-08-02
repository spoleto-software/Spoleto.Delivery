using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Ставка НДС.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<VatRate>))]
    public enum VatRate
    {
        /// <summary>
        /// Без НДС.
        /// </summary>
        [Description("Без НДС")]
        [JsonEnumValue("WO_VAT")]
        WO_VAT = -1,

        /// <summary>
        /// Ставка НДС 0%.
        /// </summary>
        [Description("Ставка НДС 0%")]
        [JsonEnumValue("0")]
        NO_VAT = 0,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [Description("Ставка НДС 10%")]
        [JsonEnumValue("10")]
        VAT_10 = 10,

        /// <summary>
        /// Ставка НДС 20%.
        /// </summary>
        [Description("Ставка НДС 20%")]
        [JsonEnumValue("20")]
        VAT_20 = 20
    }
}
