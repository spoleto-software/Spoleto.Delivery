namespace Spoleto.Delivery
{
    /// <summary>
    /// Товар в упаковке.
    /// </summary>
    public record DeliveryPackageItem
    {
        /// <summary>
        /// Наименование товара (может также содержать описание товара: размер, цвет).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор/артикул товара.
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Маркировка товара.
        /// </summary>
        public string? Marking { get; set; }

        /// <summary>
        /// Оплата за товар при получении (за единицу товара в валюте страны получателя, значение >=0) — наложенный платеж, в случае предоплаты значение = 0.
        /// </summary>
        public DeliveryItemPayment Payment { get; set; }

        /// <summary>
        /// Объявленная стоимость товара (за единицу товара в валюте взаиморасчетов, значение >=0). С данного значения рассчитывается страховка.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Вес (за единицу товара, в граммах).
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Вес брутто.
        /// </summary>
        public int? WeightGross { get; set; }

        /// <summary>
        /// Количество единиц товара (в штуках).
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Наименование на иностранном языке.
        /// </summary>
        public string? NameInternational { get; set; }

        /// <summary>
        /// Бренд на иностранном языке.
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Код страны производителя товара в формате ISO_3166-1_alpha-2.
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Код материала.
        /// </summary>
        public MaterialType? Material { get; set; }

        /// <summary>
        /// Содержит wifi/gsm.
        /// </summary>
        public bool? WifiGsm { get; set; }

        /// <summary>
        /// Ссылка на сайт интернет-магазина с описанием товара.
        /// </summary>
        public string? Url { get; set; }
    }
}