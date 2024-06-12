namespace Spoleto.Delivery
{
    /// <summary>
    /// Контактное лицо.
    /// </summary>
    public record Contact
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// ФИО контактного лица.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Электронный адрес, используется для оповещений. Должен соответствовать RFC 2822.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        public string? PassportSeries { get; set; }

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string? PassportNumber { get; set; }

        /// <summary>
        /// Дата выдачи паспорта.
        /// </summary>
        public DateTime? PassportDateOfIssue { get; set; }

        /// <summary>
        /// Орган выдачи паспорта.
        /// </summary>
        public string? PassportOrganization { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        public string? Inn { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? PassportDateOfBirth { get; set; }

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
