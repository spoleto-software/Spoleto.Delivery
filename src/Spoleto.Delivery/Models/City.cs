namespace Spoleto.Delivery
{
    public record City
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
        /// Наименование города.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор ФИАС.
        /// </summary>
        public Guid? FiasId { get; set; }

        /// <summary>
        /// Код КЛАДР.
        /// </summary>
        public string? KladrCode { get; set; }

        /// <summary>
        /// Наименование области города.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Наименование страны.
        /// </summary>
        public string Country { get; set; }
    }
}
