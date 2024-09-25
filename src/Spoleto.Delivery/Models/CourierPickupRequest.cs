namespace Spoleto.Delivery
{
    /// <summary>
    /// The courier pickup order request to create using in <see cref="CreateDeliveryOrderRequest.CourierPickupRequest"/>.
    /// </summary>
    public record CourierPickupRequest
    {
        /// <summary>
        /// Дата ожидания курьера.
        /// </summary>
        public DateTime IntakeDate { get; set; }

        /// <summary>
        /// Время начала ожидания курьера.
        /// </summary>
        public TimeSpan IntakeTimeFrom { get; set; }

        /// <summary>
        /// Время окончания ожидания курьера.
        /// </summary>
        public TimeSpan IntakeTimeTo { get; set; }

        /// <summary>
        /// Время начала обеда, должно входить в диапазон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        public TimeSpan? LunchTimeFrom { get; set; }

        /// <summary>
        /// Время окончания обеда, должно входить в диапазон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        public TimeSpan? LunchTimeTo { get; set; }

        /// <summary>
        /// Комментарий к заявке для курьера.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Необходим прозвон отправителя (по умолчанию - false).
        /// </summary>
        public bool? NeedCall { get; set; }

        /// <summary>
        /// Курьеру необходима доверенность (по умолчанию - false).
        /// </summary>
        public bool? CourierPowerOfAttorney { get; set; }

        /// <summary>
        /// Курьеру необходим документ удостоверяющий личность (по умолчанию - false).
        /// </summary>
        public bool? CourierIdentityCard { get; set; }
    }
}
