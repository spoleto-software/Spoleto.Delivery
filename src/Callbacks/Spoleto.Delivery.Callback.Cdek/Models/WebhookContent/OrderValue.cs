using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Callback.Cdek.Models
{
    /// <summary>
    /// Новое значение.
    /// </summary>
    public record OrderValue
    {
        /// <summary>
        /// Тип нового значения. Может принимать значение
        /// DATE (дата: формат YYYY-MM-DD)
        /// FLOAT (числовое значение с плавающей точкой)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Новое значение 
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}