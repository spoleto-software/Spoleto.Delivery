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

        //todo: указать возможность указания параметра с привязкой к конкректной доп услуги (не у всех доп услуг будут параметры)
        public bool ParameterRequired => ParameterType != null;

        public ParameterType? ParameterType { get;set; }
    }
}
