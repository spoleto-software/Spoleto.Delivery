using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// Дополнительная услуга для заказа на доставку.
    /// </summary>
    public record AdditionalServiceBase
    {
        /// <summary>
        /// Код услуги.
        /// </summary>
        [JsonPropertyName("code")]
        [JsonConverter(typeof(JsonEnumValueConverter<AdditionalServiceType>))]
        public AdditionalServiceType Code { get; set; }

        /// <summary>
        /// Параметр дополнительной услуги.
        /// </summary>
        /// <remarks>
        /// 1. количество для услуг PACKAGE_1, CARTON_BOX_XS, CARTON_BOX_S, CARTON_BOX_M, CARTON_BOX_L, CARTON_BOX_500GR, CARTON_BOX_1KG, CARTON_BOX_2KG, CARTON_BOX_3KG, CARTON_BOX_5KG, CARTON_BOX_10KG, CARTON_BOX_15KG, CARTON_BOX_20KG, CARTON_BOX_30KG, CARTON_FILLER (для всех типов заказа).<br/>
        /// 2. объявленная стоимость заказа для услуги INSURANCE (только для заказов с типом "доставка").<br/>
        /// 3. длина для услуг BUBBLE_WRAP, WASTE_PAPER (для всех типов заказа).<br/>
        /// 4. номер телефона для услуги SMS.<br/>
        /// 5. код фотопроекта для услуги PHOTO_OF_DOCUMENTS.
        /// </remarks>
        [JsonPropertyName("parameter")]
        public string? Parameter { get; set; }
    }




}
