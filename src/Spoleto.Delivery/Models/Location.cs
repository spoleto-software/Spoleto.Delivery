﻿namespace Spoleto.Delivery
{
    /// <summary>
    /// Класс для представления локации (местоположения).
    /// </summary>
    public record Location
    {
        /// <summary>
        /// Код населенного пункта.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Код страны в формате ISO_3166-1_alpha-2 (по умолчанию RU)
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Полная строка адреса
        /// </summary>
        public string? Address { get; set; }
    }
}
