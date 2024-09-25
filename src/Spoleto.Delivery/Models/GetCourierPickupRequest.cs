namespace Spoleto.Delivery
{
    /// <summary>
    /// The courier pickup order request to get.
    /// </summary>
    public record GetCourierPickupRequest
    {
        /// <summary>
        /// Получает или задает идентификатор заявки в ИС конкретного провайдера (Сдэк, МастерПост).
        /// </summary>
        public Guid Uuid { get; set; }
    }
}
