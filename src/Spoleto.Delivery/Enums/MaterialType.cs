using System.ComponentModel;

namespace Spoleto.Delivery
{
    /// <summary>
    /// Перечисление типов материалов
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// Полиэстер
        /// </summary>
        [Description("Полиэстер")]
        Polyester = 1,

        /// <summary>
        /// Нейлон
        /// </summary>
        [Description("Нейлон")]
        Nylon = 2,

        /// <summary>
        /// Флис
        /// </summary>
        [Description("Флис")]
        Fleece = 3,

        /// <summary>
        /// Хлопок
        /// </summary>
        [Description("Хлопок")]
        Cotton = 4,

        /// <summary>
        /// Текстиль
        /// </summary>
        [Description("Текстиль")]
        Textile = 5,

        /// <summary>
        /// Лён
        /// </summary>
        [Description("Лён")]
        Linen = 6,

        /// <summary>
        /// Вискоза
        /// </summary>
        [Description("Вискоза")]
        Viscose = 7,

        /// <summary>
        /// Шелк
        /// </summary>
        [Description("Шелк")]
        Silk = 8,

        /// <summary>
        /// Шерсть
        /// </summary>
        [Description("Шерсть")]
        Wool = 9,

        /// <summary>
        /// Кашемир
        /// </summary>
        [Description("Кашемир")]
        Cashmere = 10,

        /// <summary>
        /// Кожа
        /// </summary>
        [Description("Кожа")]
        Leather = 11,

        /// <summary>
        /// Кожзам
        /// </summary>
        [Description("Кожзам")]
        FauxLeather = 12,

        /// <summary>
        /// Искусственный мех
        /// </summary>
        [Description("Искусственный мех")]
        FauxFur = 13,

        /// <summary>
        /// Замша
        /// </summary>
        [Description("Замша")]
        Suede = 14,

        /// <summary>
        /// Полиуретан
        /// </summary>
        [Description("Полиуретан")]
        Polyurethane = 15,

        /// <summary>
        /// Спандекс
        /// </summary>
        [Description("Спандекс")]
        Spandex = 16,

        /// <summary>
        /// Резина
        /// </summary>
        [Description("Резина")]
        Rubber = 17
    }
}
