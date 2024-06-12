using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    [JsonConverter(typeof(JsonEnumValueConverter<ContragentType>))]
    public enum ContragentType
    {
        /// <summary>
        /// Юридическое лицо
        /// </summary>
        [Description("Юридическое лицо")]
        [JsonEnumValue("LEGAL_ENTITY")]
        LegalEntity,

        /// <summary>
        /// Физическое лицо
        /// </summary>
        [Description("Физическое лицо")]
        [JsonEnumValue("INDIVIDUAL")]
        Indivial
    }
}
