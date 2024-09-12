using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    /// <summary>
    /// CDEK delivery point.
    /// </summary>
    /// <remarks>
    /// <see href="https://api-docs.cdek.ru/36982648.html"/>
    /// </remarks>
    public record DeliveryPoint
    {
        /// <summary>
        /// Код.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Название (устаревшее поле, рекомендуется использовать параметры из <see cref="Location"/>).
        /// </summary>
        [Obsolete("Use the information from the propety Location")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор офиса в ИС СДЭК.
        /// </summary>
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Адрес офиса.
        /// </summary>
        [JsonPropertyName("location")]
        public DeliveryPointLocation Location { get; set; }

        /// <summary>
        /// Описание местоположения.
        /// </summary>
        [JsonPropertyName("address_comment")]
        public string? AddressComment { get; set; }

        /// <summary>
        /// Ближайшая станция/остановка транспорта.
        /// </summary>
        [JsonPropertyName("nearest_station")]
        public string? NearestStation { get; set; }

        /// <summary>
        /// Ближайшая станция метро.
        /// </summary>
        [JsonPropertyName("nearest_metro_station")]
        public string? NearestMetroStation { get; set; }

        /// <summary>
        /// Режим работы, строка вида «пн-пт 9-18, сб 9-16».
        /// </summary>
        [JsonPropertyName("work_time")]
        public string WorkTime { get; set; }

        /// <summary>
        /// Список телефонов.
        /// </summary>
        [JsonPropertyName("phones")]
        public List<Phone> Phones { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Примечание по офису.
        /// </summary>
        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// Тип ПВЗ: PVZ — склад СДЭК, POSTAMAT — постамат.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<DeliveryPointType>))]
        public DeliveryPointType Type { get; set; }

        /// <summary>
        /// Принадлежность офиса компании.
        /// </summary>
        [JsonPropertyName("owner_code")]
        public string OwnerCode { get; set; }

        /// <summary>
        /// Является ли офис только пунктом выдачи или также осуществляет приём грузов.
        /// </summary>
        [JsonPropertyName("take_only")]
        public bool TakeOnly { get; set; }

        /// <summary>
        /// Является пунктом выдачи.
        /// </summary>
        [JsonPropertyName("is_handout")]
        public bool IsHandout { get; set; }

        /// <summary>
        /// Является пунктом приёма.
        /// </summary>
        [JsonPropertyName("is_reception")]
        public bool IsReception { get; set; }

        /// <summary>
        /// Есть ли примерочная.
        /// </summary>
        [JsonPropertyName("is_dressing_room")]
        public bool IsDressingRoom { get; set; }

        /// <summary>
        /// Есть безналичный расчет.
        /// </summary>
        [JsonPropertyName("have_cashless")]
        public bool HaveCashless { get; set; }

        /// <summary>
        /// Есть приём наличных.
        /// </summary>
        [JsonPropertyName("have_cash")]
        public bool HaveCash { get; set; }

        /// <summary>
        /// Есть безналичный расчёт по СБП.
        /// </summary>
        [JsonPropertyName("have_fast_payment_system")]
        public bool HaveFastPaymentSystem { get; set; }

        /// <summary>
        /// Разрешен наложенный платеж в ПВЗ.
        /// </summary>
        [JsonPropertyName("allowed_cod")]
        public bool AllowedCod { get; set; }

        /// <summary>
        /// Работает ли офис с LTL (сборный груз).
        /// </summary>
        [JsonPropertyName("is_ltl")]
        public bool? IsLtl { get; set; }

        /// <summary>
        /// Работает ли офис с "Фулфилмент. Приход".
        /// </summary>
        [JsonPropertyName("fulfillment")]
        public bool? Fulfillment { get; set; }

        /// <summary>
        /// Ссылка на данный офис на сайте СДЭК.
        /// </summary>
        [JsonPropertyName("site")]
        public string? Site { get; set; }

        /// <summary>
        /// Все фото офиса (кроме фото как доехать).
        /// </summary>
        [JsonPropertyName("office_image_list")]
        public List<ImageInfo>? OfficeImageList { get; set; }

        /// <summary>
        /// График работы на неделю.
        /// </summary>
        [JsonPropertyName("work_time_list")]
        public List<WorkTime> WorkTimeList { get; set; }

        /// <summary>
        /// Исключения в графике работы офиса.
        /// </summary>
        [JsonPropertyName("work_time_exception_list")]
        public List<WorkTimeException>? WorkTimeExceptionList { get; set; }

        /// <summary>
        /// Исключения в графике работы офиса.
        /// </summary>
        /// <remarks>
        /// Устаревшее поле. Необходимо использовать поле <see cref="WorkTimeExceptionList"/>.
        /// </remarks>
        [JsonPropertyName("work_time_exceptions")]
        [Obsolete("Use the property WorkTimeExceptionList")]
        public List<WorkTimeExceptionLegacy>? WorkTimeExceptions { get; set; }

        /// <summary>
        /// Минимальный вес (в кг), принимаемый в ПВЗ (> WeightMin).
        /// </summary>
        [JsonPropertyName("weight_min")]
        public double? WeightMin { get; set; }

        /// <summary>
        /// Максимальный вес (в кг), принимаемый в ПВЗ (<= WeightMax).
        /// </summary>
        [JsonPropertyName("weight_max")]
        public double? WeightMax { get; set; }

        /// <summary>
        /// Перечень максимальных размеров ячеек (только для type = POSTAMAT).
        /// </summary>
        [JsonPropertyName("dimensions")]
        public List<Dimension>? Dimensions { get; set; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<Error>? Errors { get; set; }
    }
}
