using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    [JsonConverter(typeof(JsonEnumValueConverter<PrintingReceiptType>))]
    public enum PrintingReceiptType
    {
        [JsonEnumValue("tpl_russia")]
        TplRussia,

        [JsonEnumValue("tpl_china")]
        TplChina,

        [JsonEnumValue("tpl_armenia")]
        TplArmenia,

        [JsonEnumValue("tpl_english")]
        TplEnglish,

        [JsonEnumValue("tpl_italian")]
        TplItalian,

        [JsonEnumValue("tpl_korean")]
        TplKorean,

        [JsonEnumValue("tpl_latvian")]
        TplLatvian,

        [JsonEnumValue("tpl_lithuanian")]
        TplLithuanian,

        [JsonEnumValue("tpl_german")]
        TplGerman,

        [JsonEnumValue("tpl_turkish")]
        TplTurkish,

        [JsonEnumValue("tpl_czech")]
        TplCzech,

        [JsonEnumValue("tpl_thailand")]
        TplThailand,

        [JsonEnumValue("tpl_invoice")]
        TplInvoice
    }
}
