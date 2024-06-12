using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид вложимого.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<CargoPlaceType>))]
    public enum CargoPlaceType
    {
        /// <summary>
        /// Документ
        /// </summary>
        [Description("Документ")]
        [JsonEnumValue("Документ")]
        Document,

        /// <summary>
        /// Груз
        /// </summary>
        [Description("Груз")]
        [JsonEnumValue("Груз")]
        Cargo,

        /// <summary>
        /// Ценный груз
        /// </summary>
        [Description("Ценный груз")]
        [JsonEnumValue("Ценный груз")]
        ValuableCargo,

        /// <summary>
        /// Опасный груз
        /// </summary>
        [Description("Опасный груз")]
        [JsonEnumValue("Опасный груз")]
        DangerousCargo
    }
}
