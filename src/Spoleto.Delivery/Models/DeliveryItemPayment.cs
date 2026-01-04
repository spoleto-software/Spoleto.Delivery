namespace Spoleto.Delivery
{
    /// <summary>
    /// Оплата за товар.
    /// </summary>
    public record DeliveryItemPayment
    {
        /// <summary>
        /// Сумма наложенного платежа, в том числе и НДС (в случае предоплаты = 0).
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Сумма НДС.
        /// </summary>
        public decimal? VatSum { get; set; }

        /// <summary>
        /// Ставка НДС (значение - 0, 10, 12, 20, 22, null - нет НДС).
        /// </summary>
        public int? VatRate { get; set; }
    }
}