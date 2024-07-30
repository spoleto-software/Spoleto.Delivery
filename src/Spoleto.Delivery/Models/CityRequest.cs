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
        public int? NumCode
        {
            get
            {
                if (int.TryParse(Code, out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Уникальный код города внутри провайдера.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Уникальный идентификатор ФИАС населенного пункта.
        /// </summary>
        public Guid? FiasGuid { get; set; }

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