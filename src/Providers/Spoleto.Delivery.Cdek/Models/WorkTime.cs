using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// График работы офиса на неделю.
    /// </summary>
    public record WorkTime
    {
        /// <summary>
        /// Порядковый номер дня, начиная с единицы.
        /// </summary>
        /// <remarks>
        ///  Понедельник = 1, воскресенье = 7.
        ///  </remarks>
        [JsonPropertyName("day")]
        public int Day { get; set; }

        /// <summary>
        /// Период работы в эти дни.
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; }
    }
}