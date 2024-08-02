using System.ComponentModel;
using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Тип сущности, связанной с заказом.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<OrderRelatedEntityType>))]
    public enum OrderRelatedEntityType
    {
        /// <summary>
        /// Возвратный заказ (возвращается для прямого, если заказ не вручен и по нему уже был сформирован возвратный заказ)
        /// </summary>
        [JsonEnumValue("return_order")]
        [Description("Возвратный заказ (возвращается для прямого, если заказ не вручен и по нему уже был сформирован возвратный заказ)")]
        ReturnOrder,

        /// <summary>
        /// Прямой заказ (возвращается для возвратного и реверсного заказа)
        /// </summary>
        [JsonEnumValue("direct_order")]
        [Description("Прямой заказ (возвращается для возвратного и реверсного заказа)")]
        DirectOrder,

        /// <summary>
        /// Квитанция к заказу (возвращается для заказа, по которому есть сформированная квитанция)
        /// </summary>
        [JsonEnumValue("waybill")]
        [Description("Квитанция к заказу (возвращается для заказа, по которому есть сформированная квитанция)")]
        Waybill,

        /// <summary>
        /// ШК места к заказу (возвращается для заказа, по которому есть сформированный ШК места)
        /// </summary>
        [JsonEnumValue("barcode")]
        [Description("ШК места к заказу (возвращается для заказа, по которому есть сформированный ШК места)")]
        Barcode,

        /// <summary>
        /// Реверсный заказ (возвращается для прямого заказа, если подключен реверс)
        /// </summary>
        [JsonEnumValue("reverse_order")]
        [Description("Реверсный заказ (возвращается для прямого заказа, если подключен реверс)")]
        ReverseOrder,

        /// <summary>
        /// Актуальная договоренность о доставке
        /// </summary>
        [JsonEnumValue("delivery")]
        [Description("Актуальная договоренность о доставке")]
        Delivery,

        /// <summary>
        /// Заказ клиентский возврат (возвращается для прямого заказа, к которому привязан клиентский возврат)
        /// </summary>
        [JsonEnumValue("client_return_order")]
        [Description("Заказ клиентский возврат (возвращается для прямого заказа, к которому привязан клиентский возврат)")]
        ClientReturnOrder,

        /// <summary>
        /// Прямой заказ, по которому оформлен клиентский возврат
        /// </summary>
        [JsonEnumValue("client_direct_order")]
        [Description("Прямой заказ, по которому оформлен клиентский возврат")]
        ClientDirectOrder
    }
}
