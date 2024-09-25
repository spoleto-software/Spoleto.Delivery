namespace Spoleto.Delivery
{
    /// <summary>
    /// Ошибка.
    /// </summary>
    public record Error
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        public string Message { get; set; }

        public override string ToString() => $"{Message} ({Code})";
    }
}
