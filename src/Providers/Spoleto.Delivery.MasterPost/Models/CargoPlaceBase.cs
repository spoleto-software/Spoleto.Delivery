using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Класс для представления информации о грузо-месте.
    /// </summary>
    public record CargoPlaceBase
    {
        /// <summary>
        /// ВесФактический, кг.
        /// </summary>
        [JsonPropertyName("PLACE_WEIGHT_ACT")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Длина, см.
        /// </summary>
        [JsonPropertyName("PLACE_LENGHT")]
        public int Length { get; set; }

        /// <summary>
        /// Ширина, см.
        /// </summary>
        [JsonPropertyName("PLACE_WIDTH")]
        public int Width { get; set; }

        /// <summary>
        /// Высота, см.
        /// </summary>
        [JsonPropertyName("PLACE_HEIGHT")]
        public int Height { get; set; }

        /// <summary>
        /// Вид вложимого.
        /// </summary>
        [JsonPropertyName("PLACE_CARGO_TYPE")]
        [JsonConverter(typeof(JsonEnumValueConverter<CargoPlaceType>))]
        public CargoPlaceType CargoPlaceType { get; set; }
    }
}
