﻿using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.MasterPost
{
    /// <summary>
    /// Запрос для получения списка улиц.
    /// </summary>
    public record StreetRequest
    {
        /// <summary>
        /// Код ФИАС для города.
        /// </summary>
        /// <remarks>
        /// Если передать <see cref="CityKladrCode"/> и <see cref="CityFiasId"/>, то параметр <see cref="CityKladrCode>"/> игнорируется и выбор города идет по <see cref="CityFiasId"/>.
        /// </remarks>
        [JsonPropertyName("city_fias")]
        public Guid? CityFiasId { get; set; }

        /// <summary>
        /// Код КЛАДР для города.
        /// </summary>
        /// <remarks>
        /// Если передать <see cref="CityKladrCode"/> и <see cref="CityFiasId"/>, то параметр <see cref="CityKladrCode>"/> игнорируется и выбор города идет по <see cref="CityFiasId"/>.
        /// </remarks>
        [JsonPropertyName("city_klad")]
        public string CityKladrCode { get; set; }

        /// <summary>
        /// Фильтр для поиска улиц.
        /// </summary>
        [JsonPropertyName("filter")]
        public string Filter { get; set; }
    }
}
