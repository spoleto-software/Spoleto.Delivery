namespace Spoleto.Delivery
{
    /// <summary>
    /// Услуги тарифа доставки.
    /// </summary>
    public record TariffService
    {
        /// <summary>
        /// Вид услуги
        /// </summary>
        public string RatePart { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// НДС
        /// </summary>
        public decimal Vat { get; set; }

        /// <summary>
        /// Коэффициент
        /// </summary>
        public decimal Coefficient { get; set; }
    }
}