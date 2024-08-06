using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Валюта.
    /// </summary>
    [JsonConverter(typeof(JsonIntEnumConverter<Currency>))]
    public enum Currency
    {
        /// <summary>
        /// Российский рубль
        /// </summary>
        /// <remarks>
        /// Код валюты: RUB
        /// </remarks>
        [Description("Российский рубль")]
        RussianRuble = 1,

        /// <summary>
        /// Тенге
        /// </summary>
        /// <remarks>
        /// Код валюты: KZT
        /// </remarks>
        [Description("Тенге")]
        Tenge = 2,

        /// <summary>
        /// Доллар США
        /// </summary>
        /// <remarks>
        /// Код валюты: USD
        /// </remarks>
        [Description("Доллар США")]
        UsDollar = 3,

        /// <summary>
        /// Евро
        /// </summary>
        /// <remarks>
        /// Код валюты: EUR
        /// </remarks>
        [Description("Евро")]
        Euro = 4,

        /// <summary>
        /// Фунт Стерлингов
        /// </summary>
        /// <remarks>
        /// Код валюты: GBP
        /// </remarks>
        [Description("Фунт Стерлингов")]
        PoundSterling = 5,

        /// <summary>
        /// Китайский юань
        /// </summary>
        /// <remarks>
        /// Код валюты: CNY
        /// </remarks>
        [Description("Китайский юань")]
        ChineseYuan = 6,

        /// <summary>
        /// Беларусский рубль
        /// </summary>
        /// <remarks>
        /// Код валюты: BYR
        /// </remarks>
        [Description("Беларусский рубль")]
        BelarusianRuble = 7,

        /// <summary>
        /// Гривна
        /// </summary>
        /// <remarks>
        /// Код валюты: UAH
        /// </remarks>
        [Description("Гривна")]
        Hryvnia = 8,

        /// <summary>
        /// Киргизский сом
        /// </summary>
        /// <remarks>
        /// Код валюты: KGS
        /// </remarks>
        [Description("Киргизский сом")]
        KyrgyzSom = 9,

        /// <summary>
        /// Армянский драм
        /// </summary>
        /// <remarks>
        /// Код валюты: AMD
        /// </remarks>
        [Description("Армянский драм")]
        ArmenianDram = 10,

        /// <summary>
        /// Турецкая лира
        /// </summary>
        /// <remarks>
        /// Код валюты: TRY
        /// </remarks>
        [Description("Турецкая лира")]
        TurkishLira = 11,

        /// <summary>
        /// Тайский бат
        /// </summary>
        /// <remarks>
        /// Код валюты: THB
        /// </remarks>
        [Description("Тайский бат")]
        ThaiBaht = 12,

        /// <summary>
        /// Вон
        /// </summary>
        /// <remarks>
        /// Код валюты: KRW
        /// </remarks>
        [Description("Вон")]
        Won = 13,

        /// <summary>
        /// Дирхам
        /// </summary>
        /// <remarks>
        /// Код валюты: AED
        /// </remarks>
        [Description("Дирхам")]
        Dirham = 14,

        /// <summary>
        /// Узбекский сум
        /// </summary>
        /// <remarks>
        /// Код валюты: UZS
        /// </remarks>
        [Description("Узбекский сум")]
        UzbekSum = 15,

        /// <summary>
        /// Тугрик
        /// </summary>
        /// <remarks>
        /// Код валюты: MNT
        /// </remarks>
        [Description("Тугрик")]
        Tugrik = 16,

        /// <summary>
        /// Злотый
        /// </summary>
        /// <remarks>
        /// Код валюты: PLN
        /// </remarks>
        [Description("Злотый")]
        Zloty = 17,

        /// <summary>
        /// Манат
        /// </summary>
        /// <remarks>
        /// Код валюты: AZN
        /// </remarks>
        [Description("Манат")]
        Manat = 18,

        /// <summary>
        /// Лари
        /// </summary>
        /// <remarks>
        /// Код валюты: GEL
        /// </remarks>
        [Description("Лари")]
        Lari = 19,

        /// <summary>
        /// Йена
        /// </summary>
        /// <remarks>
        /// Код валюты: JPY
        /// </remarks>
        [Description("Йена")]
        Yen = 55
    }
}
