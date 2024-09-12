namespace Spoleto.Delivery
{
    /// <summary>
    /// График работы офиса на неделю.
    /// </summary>
    public record WorkTime
    {
        /// <summary>
        /// Порядковый номер дня, начиная с единицы.
        /// </summary>
        /// <remarks>
        ///  Понедельник = 1, воскресенье = 7.
        ///  </remarks>
        public int Day { get; set; }

        /// <summary>
        /// Период работы в эти дни.
        /// </summary>
        public string Time { get; set; }
    }
}