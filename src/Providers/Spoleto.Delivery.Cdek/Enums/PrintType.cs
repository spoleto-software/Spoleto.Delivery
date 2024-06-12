using System.ComponentModel;
using Spoleto.Common.JsonConverters;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип печатной формы при формировании заказа на доставку.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<PrintType>))]
    public enum PrintType
    {
        /// <summary>
        /// ШК мест (число копий - 1)
        /// </summary>
        [Description("ШК мест (число копий - 1)")]
        [JsonEnumValue("barcode")]
        Barcode,

        /// <summary>
        /// квитанция (число копий - 2)
        /// </summary>
        [Description("квитанция (число копий - 2)")]
        [JsonEnumValue("waybill")]
        Waybill
    }
}
