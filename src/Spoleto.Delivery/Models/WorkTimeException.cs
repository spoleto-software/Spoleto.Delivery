namespace Spoleto.Delivery
{
    /// <summary>
    /// Исключения в графике работы офиса.
    /// </summary>
    public record WorkTimeException
    {
        /// <summary>
        /// Дата начала исключения в работе офиса.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания исключения в работе офиса.
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Время начала работы в указанную дату
        /// </summary>
        public TimeSpan? TimeStart { get; set; }

        /// <summary>
        /// Время окончания работы в указанную дату.
        /// </summary>
        public TimeSpan? TimeEnd { get; set; }

        /// <summary>
        /// Признак рабочего/нерабочего дня в указанную дату.
        /// </summary>
        public bool IsWorking { get; set; }
    }
}