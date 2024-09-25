namespace Spoleto.Delivery
{
    /// <summary>
    /// The courier pickup order request to create.
    /// </summary>
    public record CreateCourierPickupRequest
    {
        /// <summary>
        /// Получает или задает идентификатор заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? OrderUuid { get; set; }

        /// <summary>
        /// Номер заказа в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? OrderNumber { get; set; }

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
        /// Описание груза.
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public string? Name { get; set; }

        /// <summary>
        /// Общий вес (в граммах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public int? Weight { get; set; }

        /// <summary>
        /// Габариты упаковки. Длина (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public int? Length { get; set; }

        /// <summary>
        /// Габариты упаковки. Ширина (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public int? Width { get; set; }

        /// <summary>
        /// Габариты упаковки. Высота (в сантиметрах).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public int? Height { get; set; }

        /// <summary>
        /// Комментарий к заявке для курьера.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// Если номер заказа передан, данные об отправителе будут взяты из этого заказа.
        /// </remarks>
        public ContactBase? Sender { get; set; }

        /// <summary>
        /// Адрес отправителя (забора).
        /// </summary>
        /// <remarks>
        /// Необходимо заполнять, если не передан номер заказа. Иначе значение берется из заказа.
        /// </remarks>
        public CourierPickupLocation? FromLocation { get; set; }

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
