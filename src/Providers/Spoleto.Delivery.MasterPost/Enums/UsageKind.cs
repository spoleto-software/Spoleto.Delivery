using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид использования дополнительной услуги.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<UsageKind>))]
    public enum UsageKind
    {
        /// <summary>
        /// Опционально.
        /// </summary>
        [Description("Опционально")]
        [JsonEnumValue("Опционально")]
        Optional,

        /// <summary>
        /// Никогда.
        /// </summary>
        [Description("Никогда")]
        [JsonEnumValue("Никогда")]
        Never,

        /// <summary>
        /// Всегда.
        /// </summary>
        [Description("Всегда")]
        [JsonEnumValue("Всегда")]
        Always
    }
}
