namespace Spoleto.Delivery
{
    /// <summary>
    /// The additional delivery service.
    /// </summary>
    public record AdditionalService
    {
        /// <summary>
        /// Код услуги.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование услуги.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание услуги.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Параметр услуги.
        /// </summary>
        public string? Parameter { get; set; }

        public bool ParameterRequired => ParameterType != null || Parameter != null;

        public ParameterType? ParameterType { get;set; }

        /// <summary>
        /// Общая сумма (итого с НДС и скидкой в валюте взаиморасчётов).
        /// </summary>
        public decimal? TotalSum { get; set; }
    }
}
