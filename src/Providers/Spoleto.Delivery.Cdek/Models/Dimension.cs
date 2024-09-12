using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Размеры ячейки (только для type = <see cref="DeliveryPointType.Postamat"/>).
    /// </summary>
    public record Dimension
    {
        /// <summary>
        /// Ширина (см).
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// Высота (см).
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// Глубина (см).
        /// </summary>
        [JsonPropertyName("depth")]
        public double Depth { get; set; }
    }
}