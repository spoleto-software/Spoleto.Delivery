using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Класс для представления информации о грузо-месте.
    /// </summary>
    public record CargoPlace : CargoPlaceBase
    {
        /// <summary>
        /// Идентификатор места.
        /// </summary>
        [JsonPropertyName("PLACE_IDENT")]
        public string? Id { get; set; }

        /// <summary>
        /// Серийный номер, требуемый к сбору.
        /// </summary>
        [JsonPropertyName("PLACE_EXPECTED_SN")]
        public string? ExpectedSerialNumber { get; set; }
    }
}
