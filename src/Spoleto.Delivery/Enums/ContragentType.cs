using System.ComponentModel;

namespace Spoleto.Delivery
{
    public enum ContragentType
    {
        /// <summary>
        /// Юридическое лицо
        /// </summary>
        [Description("Юридическое лицо")]
        LegalEntity,

        /// <summary>
        /// Физическое лицо
        /// </summary>
        [Description("Физическое лицо")]
        Indivial
    }
}
