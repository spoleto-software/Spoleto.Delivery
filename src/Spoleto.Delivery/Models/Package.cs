namespace Spoleto.Delivery
{
    /// <summary>
    /// Класс для представления информации о пакете.
    /// </summary>
    public record Package
    {
        /// <summary>
        /// Общий вес (в граммах).
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Длина (в сантиметрах).
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Ширина (в сантиметрах).
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота (в сантиметрах).
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Вид пакета.
        /// </summary>
        public PackageType? PackageType { get; set; }
    }
}
