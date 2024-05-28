namespace Spoleto.Delivery
{
    public record City
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
        /// Наименование города.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код ФИАС.
        /// </summary>
        public Guid? FiasCode { get; set; }

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
