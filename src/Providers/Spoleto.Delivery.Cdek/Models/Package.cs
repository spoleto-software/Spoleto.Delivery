using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Класс для представления информации о пакете
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    public record Package
    {
        /// <summary>
        /// Общий вес (в граммах)
        /// </summary>
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Длина (в сантиметрах)
        /// </summary>
        [JsonPropertyName("length")]
        public int? Length { get; set; }

        /// <summary>
        /// Ширина (в сантиметрах)
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Высота (в сантиметрах)
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
    }
}
