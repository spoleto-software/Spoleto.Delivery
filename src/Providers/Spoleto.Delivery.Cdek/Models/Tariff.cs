using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/63345519.html"/>
    /// </remarks>
    internal record Tariff
    {
        /// <summary>
        /// Режим доставки.
        /// </summary>
        [JsonPropertyName("DEL_MODE")]
        public string Name { get; set; }
    }
}
