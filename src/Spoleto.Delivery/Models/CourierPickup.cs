namespace Spoleto.Delivery
{
    /// <summary>
    /// The courier pickup order.
    /// </summary>
    public record CourierPickup
    {
        /// <summary>
        /// Получает или задает идентификатор заявки на вызов курьера в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? Uuid { get; set; }

        /// <summary>
        /// Номер заявки на вызов курьера в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Номер заказа на доставку в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public string? OrderNumber { get; set; }

        /// <summary>
        /// Идентификатор заказа на доставку в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid? OrderUuid { get; set; }

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
        /// Время начала обеда, должно входить в диапозон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        public TimeSpan? LunchTimeFrom { get; set; }

        /// <summary>
        /// Время окончания обеда, должно входить в диапозон [<see cref="IntakeTimeFrom"/>; <see cref="IntakeTimeTo"/>].
        /// </summary>
        public TimeSpan? LunchTimeTo { get; set; }

        /// <summary>
        /// Описание груза.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Общий вес (в граммах).
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Габариты упаковки. Длина (в сантиметрах).
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Габариты упаковки. Ширина (в сантиметрах).
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Габариты упаковки. Высота (в сантиметрах).
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Комментарий к заявке для курьера.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        public ContactBase? Sender { get; set; }

        /// <summary>
        /// Адрес отправителя (забора).
        /// </summary>
        public CourierPickupLocation? FromLocation { get; set; }

        /// <summary>
        /// Необходим прозвон отправителя (по умолчанию - false).
        /// </summary>
        public bool? NeedCall { get; set; }

        /// <summary>
        /// Текущий статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Флаг, что заявка на вызов курьера была удалена.
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Курьеру необходима доверенность (по умолчанию - false).
        /// </summary>
        public bool? CourierPowerOfAttorney { get; set; }

        /// <summary>
        /// Курьеру необходим документ удостоверяющий личность (по умолчанию - false).
        /// </summary>
        public bool? CourierIdentityCard { get; set; }

        /// <summary>
        /// Получает или задает ошибки, возникшие в ходе выполнения запроса.
        /// </summary>
        public List<Error>? Errors { get; set; }

        /// <summary>
        /// Получает или задает предупреждения, возникшие в ходе выполнения запроса.
        /// </summary>
        public List<Warning>? Warnings { get; set; }
    }
}
