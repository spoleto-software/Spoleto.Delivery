namespace Spoleto.Delivery
{
    public record Warning
    {
        /// <summary>
        /// Получает или задает код предупреждения.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Получает или задает описание предупреждения.
        /// </summary>
        public string Message { get; set; }
    }
}
