using System.Text.Json.Serialization;

namespace Spoleto.Delivery
{
    /// <summary>
    /// Размеры ячейки (только для type = <see cref="DeliveryPointType.Postamat"/>).
    /// </summary>
    public record Dimension
    {
        /// <summary>
        /// Ширина (см).
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота (см).
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Глубина (см).
        /// </summary>
        public double Depth { get; set; }
    }
}