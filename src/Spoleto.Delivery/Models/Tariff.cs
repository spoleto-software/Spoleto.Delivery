namespace Spoleto.Delivery
{
    /// <summary>
    /// Тариф доставки.
    /// </summary>
    public record Tariff
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
