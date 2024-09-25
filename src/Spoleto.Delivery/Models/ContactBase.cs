namespace Spoleto.Delivery
{
    /// <summary>
    /// Контактное лицо.
    /// </summary>
    public record ContactBase
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// ФИО контактного лица.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список телефонов.
        /// </summary>
        public List<Phone>? Phones { get; set; }

        /// <summary>
        /// Тип отправителя.
        /// </summary>
        public ContragentType? ContragentType { get; set; }
    }
}
