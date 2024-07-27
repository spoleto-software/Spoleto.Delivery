using System.Text;
using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Товар в упаковке.
    /// </summary>
    public record DeliveryPackageItemBase
    {
        /// <summary>
        /// Наименование товара (может также содержать описание товара: размер, цвет).
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор/артикул товара.
        /// </summary>
        /// <remarks>
        /// Артикул товара может содержать только символы: [A-z А-я 0-9 ! @ " # № $ ; % ^ : & ? * () _ - + = ? < > , .{ } [ ] \ / , пробел].<br/>
        /// При передаче одинаковых артикулов в рамках одной упаковки, артикул будет заменяться на: {ware_key}_* , где * – это 7 случайных символов.
        /// </remarks>
        [JsonPropertyName("ware_key")]
        public string WareKey { get; set; }

        /// <summary>
        /// Маркировка товара.
        /// </summary>
        /// <remarks>
        /// Если для товара/вложения указана маркировка, <see cref="Amount"/> не может быть больше 1.<br/>
        /// Для корректного отображения маркировки товара в чеке требуется передавать НЕ РАЗОБРАННЫЙ тип маркировки.<br/>
        /// 1) Код товара в формате GS1<br/>
        /// Пример: 010468008549838921AAA0005255832GS91EE06GS92VTwGVc7wKCc2tqRncUZ1RU5LeUKSXjWbfNQOpQjKK+A<br/><br/>
        /// 2) Последовательность допустимых символов общей длиной в 29 символов.<br/>
        /// Пример: 00000046198488X? io+qCABm8wAYa<br/><br/>
        /// 3) Меховые изделия.Имеют собственный формат.<br/>
        /// Пример: RU-430302-AAA7582720<br/><br/>
        /// (GS следует передавать, как символ ASCII 29)
        /// </remarks>
        [JsonPropertyName("marking")]
        public string? Marking { get; set; }

        /// <summary>
        /// Оплата за товар при получении (за единицу товара в валюте страны получателя, значение >=0) — наложенный платеж, в случае предоплаты значение = 0.
        /// </summary>
        [JsonPropertyName("payment")]
        public DeliveryItemPayment Payment { get; set; }

        /// <summary>
        /// Объявленная стоимость товара (за единицу товара в валюте взаиморасчетов, значение >=0). С данного значения рассчитывается страховка.
        /// </summary>
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Вес (за единицу товара, в граммах).
        /// </summary>
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Вес брутто.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("weight_gross")]
        public int? WeightGross { get; set; }

        /// <summary>
        /// Количество единиц товара (в штуках).
        /// </summary>
        /// <remarks>
        /// Количество одного товара в заказе может быть от 1 до 999.
        /// </remarks>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Наименование на иностранном языке.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("name_i18n")]
        public string? NameI18n { get; set; }

        /// <summary>
        /// Бренд на иностранном языке.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        /// <summary>
        /// Код страны производителя товара в формате ISO_3166-1_alpha-2.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Код материала.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("material")]
        [JsonConverter(typeof(JsonIntEnumConverter<MaterialType>))]
        public MaterialType? Material { get; set; }

        /// <summary>
        /// Содержит wifi/gsm.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("wifi_gsm")]
        public bool? WifiGsm { get; set; }

        /// <summary>
        /// Ссылка на сайт интернет-магазина с описанием товара.
        /// </summary>
        /// <remarks>
        /// Только для международных заказов.
        /// </remarks>
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}