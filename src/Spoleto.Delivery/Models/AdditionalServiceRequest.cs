namespace Spoleto.Delivery
{
    /// <summary>
    /// The additional delivery service request.
    /// </summary>
    public record AdditionalServiceRequest
    {
        /// <summary>
        /// Код услуги.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Параметр услуги.
        /// </summary>
        public string? Parameter { get; set; }
    }
}
