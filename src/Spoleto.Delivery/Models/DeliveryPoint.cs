
namespace Spoleto.Delivery
{
    /// <summary>
    /// Офис, склад, пункт выдачи.
    /// </summary>
    public record DeliveryPoint
    {
        /// <summary>
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название (устаревшее поле, рекомендуется использовать параметры из <see cref="Location"/>).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор офиса в ИС транспортной компании.
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// Адрес офиса.
        /// </summary>
        public DeliveryPointLocation Location { get; set; }

        /// <summary>
        /// Описание местоположения.
        /// </summary>
        public string? AddressComment { get; set; }

        /// <summary>
        /// Ближайшая станция/остановка транспорта.
        /// </summary>
        public string? NearestStation { get; set; }

        /// <summary>
        /// Ближайшая станция метро.
        /// </summary>
        public string? NearestMetroStation { get; set; }

        /// <summary>
        /// Режим работы, строка вида «пн-пт 9-18, сб 9-16».
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// Список телефонов.
        /// </summary>
        public List<Phone> Phones { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Примечание по офису.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Тип ПВЗ: PVZ — склад, POSTAMAT — постамат .
        /// </summary>
        public DeliveryPointType Type { get; set; }

        /// <summary>
        /// Принадлежность офиса компании.
        /// </summary>
        public string OwnerCode { get; set; }

        /// <summary>
        /// Является ли офис только пунктом выдачи или также осуществляет приём грузов.
        /// </summary>
        public bool TakeOnly { get; set; }

        /// <summary>
        /// Является пунктом выдачи.
        /// </summary>
        public bool IsHandout { get; set; }

        /// <summary>
        /// Является пунктом приёма.
        /// </summary>
        public bool IsReception { get; set; }

        /// <summary>
        /// Есть ли примерочная.
        /// </summary>
        public bool IsDressingRoom { get; set; }

        /// <summary>
        /// Есть безналичный расчет.
        /// </summary>
        public bool HaveCashless { get; set; }

        /// <summary>
        /// Есть приём наличных.
        /// </summary>
        public bool HaveCash { get; set; }

        /// <summary>
        /// Есть безналичный расчёт по СБП.
        /// </summary>
        public bool HaveFastPaymentSystem { get; set; }

        /// <summary>
        /// Разрешен наложенный платеж в ПВЗ.
        /// </summary>
        public bool AllowedCod { get; set; }

        /// <summary>
        /// Работает ли офис с LTL (сборный груз).
        /// </summary>
        public bool? IsLtl { get; set; }

        /// <summary>
        /// Работает ли офис с "Фулфилмент. Приход".
        /// </summary>
        public bool? Fulfillment { get; set; }

        /// <summary>
        /// Ссылка на данный офис на сайте транспортной компании.
        /// </summary>
        public string? Site { get; set; }

        /// <summary>
        /// Все фото офиса (кроме фото как доехать).
        /// </summary>
        public List<ImageInfo>? OfficeImageList { get; set; }

        /// <summary>
        /// График работы на неделю.
        /// </summary>
        public List<WorkTime> WorkTimeList { get; set; }

        /// <summary>
        /// Исключения в графике работы офиса.
        /// </summary>
        public List<WorkTimeException>? WorkTimeExceptionList { get; set; }

        /// <summary>
        /// Минимальный вес (в кг), принимаемый в ПВЗ (> WeightMin).
        /// </summary>
        public double? WeightMin { get; set; }

        /// <summary>
        /// Максимальный вес (в кг), принимаемый в ПВЗ (<= WeightMax).
        /// </summary>
        public double? WeightMax { get; set; }

        /// <summary>
        /// Перечень максимальных размеров ячеек (только для type = POSTAMAT).
        /// </summary>
        public List<Dimension>? Dimensions { get; set; }

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<Error>? Errors { get; set; }
    }
}
