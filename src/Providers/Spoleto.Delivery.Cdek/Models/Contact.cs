using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Контактное лицо.
    /// </summary>
    public record Contact : ContactBase
    {
        /// <summary>
        /// Требования по паспортным данным удовлетворены (актуально для международных заказов):<br/>
        /// true - паспортные данные собраны или не требуются<br/>
        /// false - паспортные данные требуются и не собраны
        /// </summary>
        [JsonPropertyName("passport_requirements_satisfied")]
        public bool? PassportRequirementsSatisfied { get; set; }
    }
}
