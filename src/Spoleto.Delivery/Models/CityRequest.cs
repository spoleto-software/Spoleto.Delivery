namespace Spoleto.Delivery
{
    /// <summary>
    /// Запрос на получение списка городов.
    /// </summary>
    public record CityRequest
    {
        /// <summary>
        /// Уникальный числовой код города внутри провайдера (СДЭК).
        /// </summary>
        public int? ProviderCityNumCode
        {
            get
            {
                if (int.TryParse(ProviderCityCode, out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Уникальный код города внутри провайдера (СДЭК).
        /// </summary>
        public string? ProviderCityCode { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС населенного пункта.
        /// </summary>
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ограничение выборки результата.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Номер страницы выборки результата.
        /// </summary>
        public int? Page { get; set; }
    }
}