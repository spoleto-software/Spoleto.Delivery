namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Cdek delivery order request to print.
    /// </summary>
    public record PrintDeliveryOrderRequest
    {
        /// <summary>
        /// Gets or sets delivery orders.
        /// </summary>
        public List<PrintDeliveryOrder> DeliveryOrders { get; set; }

        /// <summary>
        /// Число копий одной квитанции на листе.
        /// </summary>
        /// <remarks>
        /// Рекомендовано указывать не менее 2, одна приклеивается на груз, вторая остается у отправителя.<br/>
        /// </remarks>
        public int? ReceiptCopyCount { get; set; }

        /// <summary>
        /// Форма квитанции. По умолчанию будет выбрана форма на русском языке.
        /// </summary>
        public PrintingReceiptType? ReceiptType { get; set; }

        /// <summary>
        /// Число копий ШК места.
        /// </summary>
        public int? BarcodeCopyCount { get; set; }

        /// <summary>
        /// Формат печати ШК места.
        /// </summary>
        public PrintingBarcodeFormat? BarcodeFormat { get; set; }

        /// <summary>
        /// Язык печатной формы ШК места.
        /// </summary>
        /// <remarks>
        /// Возможные языки в кодировке ISO - 639-3:<br/>
        /// "RUS" "ENG" "DEU" "ITA" "TUR" "CES" "KOR" "LIT" "LAV".
        /// </remarks>
        public string? BarcodeLang { get; set; }
    }
}
