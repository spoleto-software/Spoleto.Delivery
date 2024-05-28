namespace Spoleto.Delivery
{
    /// <summary>
    /// Запрос на получение списка городов.
    /// </summary>
    public record CityRequest
    {
        /// <summary>
        /// Уникальный числовой код города внутри провайдера.
        /// </summary>
        public int NumCode { get; set; }

        /// <summary>
        /// Уникальный код города внутри провайдера.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string PostalCode { get; set; }
    }
}