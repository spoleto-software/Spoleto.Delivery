using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Формат печати
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<PrintingBarcodeFormat>))]
    public enum PrintingBarcodeFormat
    {
        A4,
        A5,
        A6,
        A7
    }
}
