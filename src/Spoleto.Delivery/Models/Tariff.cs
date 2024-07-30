namespace Spoleto.Delivery
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    public record Tariff
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Код тарифа.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Числовой код тарифа.
        /// </summary>
        public int? NumCode
        {
            get
            {
                if (int.TryParse(Code, out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Название тарифа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание тарифа.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Режим тарифа.
        /// </summary>
        public int? DeliveryMode { get; set; }

        /// <summary>
        /// Стоимость доставки.
        /// </summary>
        public decimal DeliverySum { get; set; }

        /// <summary>
        /// Срок время доставки.
        /// </summary>
        public string? Period { get; set; }

        /// <summary>
        /// Минимальное время доставки (в рабочих днях).
        /// </summary>
        public int? PeriodMin { get; set; }

        /// <summary>
        /// Максимальное время доставки (в рабочих днях).
        /// </summary>
        public int? PeriodMax { get; set; }

        /// <summary>
        /// Минимальное время доставки (в календарных днях).
        /// </summary>
        public int? CalendarMin { get; set; }

        /// <summary>
        /// Максимальное время доставки (в календарных днях).
        /// </summary>
        public int? CalendarMax { get; set; }

        /// <summary>
        /// Включенные услуги.
        /// </summary>
        public List<TariffService> Services { get; set; }
    }
}
