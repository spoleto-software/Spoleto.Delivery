using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Язык.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<Language>))]
    public enum Language
    {
        /// <summary>
        /// Русский
        /// </summary>
        /// <remarks>
        /// Код языка: rus
        /// </remarks>
        [Description("Русский")]
        [JsonEnumValue("rus")]
        Russian,

        /// <summary>
        /// Английский
        /// </summary>
        /// <remarks>
        /// Код языка: eng
        /// </remarks>
        [Description("Английский")]
        [JsonEnumValue("eng")]
        English,

        /// <summary>
        /// Китайский
        /// </summary>
        /// <remarks>
        /// Код языка: zho
        /// </remarks>
        [Description("Китайский")]
        [JsonEnumValue("zho")]
        Chinese
    }
}
