using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид использования дополнительной услуги.
    /// </summary>
    [JsonConverter(typeof(JsonDescriptionEnumConverter<UsageKind>))]
    public enum UsageKind
    {
        /// <summary>
        /// Опционально.
        /// </summary>
        [Description("Опционально")]
        Optional,

        /// <summary>
        /// Никогда.
        /// </summary>
        [Description("Никогда")]
        Never,

        /// <summary>
        /// Всегда.
        /// </summary>
        [Description("Всегда")]
        Always
    }
}
