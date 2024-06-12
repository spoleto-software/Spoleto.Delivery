namespace Spoleto.Delivery
{
    /// <summary>
    /// Класс для представления информации о пакете в заказе.
    /// </summary>
    public record DeliveryOrderPackage : Package
    {
        /// <summary>
        /// Номер упаковки (можно использовать порядковый номер упаковки заказа или номер заказа), уникален в пределах заказа.<br/>
        /// Идентификатор заказа в ИС Клиента
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Комментарий к упаковке.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Вид грузо-места.
        /// </summary>
        public CargoPlaceType? CargoPlaceType { get; set; }

        /// <summary>
        /// Позиции товаров в упаковке
        /// </summary>
        public List<DeliveryPackageItem> Items { get; set; }
    }
}
