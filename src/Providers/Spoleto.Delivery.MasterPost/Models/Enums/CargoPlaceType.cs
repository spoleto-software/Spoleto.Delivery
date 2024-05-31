using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Вид вложимого.
    /// </summary>
    [JsonConverter(typeof(JsonDescriptionEnumConverter<CargoPlaceType>))]
    public enum CargoPlaceType
    {
        /// <summary>
        /// Документ
        /// </summary>
        [Description("Документ")]
        Document,

        /// <summary>
        /// Груз
        /// </summary>
        [Description("Груз")]
        Cargo,

        /// <summary>
        /// Ценный груз
        /// </summary>
        [Description("Ценный груз")]
        ValuableCargo,

        /// <summary>
        /// Опасный груз
        /// </summary>
        [Description("Опасный груз")]
        DangerousCargo
    }
}
