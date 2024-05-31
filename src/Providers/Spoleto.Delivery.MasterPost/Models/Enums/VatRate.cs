using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Ставка НДС.
    /// </summary>
    [JsonConverter(typeof(JsonDescriptionEnumConverter<VatRate>))]
    public enum VatRate
    {
        /// <summary>
        /// Без НДС.
        /// </summary>
        [Description("WO_VAT")]
        WO_VAT = -1,

        /// <summary>
        /// Ставка НДС 0%.
        /// </summary>
        [Description("0")]
        NO_VAT = 0,

        /// <summary>
        /// Ставка НДС 10%.
        /// </summary>
        [Description("10")]
        VAT_10 = 10,

        /// <summary>
        /// Ставка НДС 20%.
        /// </summary>
        [Description("20")]
        VAT_20 = 20
    }
}
