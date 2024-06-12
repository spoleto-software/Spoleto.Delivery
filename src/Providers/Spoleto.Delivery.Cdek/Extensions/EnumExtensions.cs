using System.ComponentModel;
using System.Reflection;
using Spoleto.Common.Attributes;

namespace Spoleto.Delivery.Providers.Cdek
{
    internal static class EnumExtensions
    {
        public static string? GetJsonEnumValue(this Enum enumValue, bool returnValueIfAttributeNotFound = true)
        {
            var attr = enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<JsonEnumValueAttribute>(false);
            if (attr != null)
            {
                return attr.Value;
            }

            return returnValueIfAttributeNotFound ? enumValue.ToString() : null;
        }

        public static string? GetDescription(this Enum enumValue, bool returnValueIfAttributeNotFound = true)
        {
            var attr = enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<DescriptionAttribute>(false);
            if (attr != null)
            {
                return attr.Description;
            }

            return returnValueIfAttributeNotFound ? enumValue.ToString() : null;
        }
    }
}
