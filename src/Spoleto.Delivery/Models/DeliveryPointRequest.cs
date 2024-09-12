namespace Spoleto.Delivery
{
    /// <summary>
    /// Запрос на получение списка офисов, складов, пунктов выдачи.
    /// </summary>
    public record DeliveryPointRequest
    {
        /// <summary>
        /// Почтовый индекс города, для которого необходим список офисов.
        /// </summary>
        public int? PostalCode { get; set; }

        /// <summary>
        /// Уникальный числовой код города внутри провайдера (СДЭК).
        /// </summary>
        public int? ProviderCityNumCode
        {
            get
            {
                if (int.TryParse(ProviderCityCode, out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Код населенного пункта внутри провайдера (СДЭК).
        /// </summary>
        public string? ProviderCityCode { get; set; }

        /// <summary>
        /// Тип офиса. Может принимать значения: "PVZ", "POSTAMAT", "ALL".
        /// По умолчанию "ALL".
        /// </summary>
        public DeliveryPointType? Type { get; set; }

        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2.
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Код региона по базе провайдера (транспортной компании).
        /// </summary>
        public int? RegionCode { get; set; }

        /// <summary>
        /// Наличие терминала оплаты. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        public bool? HaveCashless { get; set; }

        /// <summary>
        /// Есть прием наличных. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        public bool? HaveCash { get; set; }

        /// <summary>
        /// Разрешен наложенный платеж. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? AllowedCod { get; set; }

        /// <summary>
        /// Наличие примерочной. Может принимать значения: "1", "true" - есть; "0", "false" - нет.
        /// </summary>
        public bool? IsDressingRoom { get; set; }

        /// <summary>
        /// Максимальный вес в кг, который может принять офис.
        /// </summary>
        /// <remarks>
        /// Значения больше 0 - передаются офисы, которые принимают этот вес; 0 - офисы с нулевым весом не передаются; значение не указано - все офисы.
        /// </remarks>
        public int? WeightMax { get; set; }

        /// <summary>
        /// Минимальный вес в кг, который принимает офис.
        /// </summary>
        /// <remarks>
        /// При переданном значении будут выводиться офисы с минимальным весом до указанного значения.
        /// </remarks>
        public int? WeightMin { get; set; }

        /// <summary>
        /// Является ли офис только пунктом выдачи. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? TakeOnly { get; set; }

        /// <summary>
        /// Является пунктом выдачи. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? IsHandout { get; set; }

        /// <summary>
        /// Есть ли в офисе прием заказов. Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? IsReception { get; set; }

        /// <summary>
        /// Код города ФИАС.
        /// </summary>
        public Guid? FiasGuid { get; set; }

        /// <summary>
        /// Код ПВЗ.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Работает ли офис с LTL (сборный груз). Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? IsLtl { get; set; }

        /// <summary>
        /// Работает ли офис с "Фулфилмент. Приход". Может принимать значения: "1", "true" - да; "0", "false" - нет.
        /// </summary>
        public bool? Fulfillment { get; set; }

        /// <summary>
        /// Ограничение выборки результата (размер страницы).
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Номер страницы выборки результата. По умолчанию 0.
        /// </summary>
        public int? Page { get; set; }
    }
}