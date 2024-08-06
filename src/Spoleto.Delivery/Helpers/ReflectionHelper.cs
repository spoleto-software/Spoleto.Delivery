namespace Spoleto.Delivery.Helpers
{
    public class ReflectionHelper
    {
        public static void SetPropertyValue<T>(T obj, string propertyName, object value) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            object objValue = obj;
            var properties = propertyName.Split('.');
            if (properties.Length > 1)
            {
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var objType = objValue.GetType();
                    var property = objType.GetProperty(properties[i]);
                    if (property == null)
                        throw new ArgumentException($"Property <{properties[i]}> not found in the type <{objType.Name}>.");

                    var propertyValue = property.GetValue(objValue, null);
                    if (propertyValue == null)
                    {
                        propertyValue = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(objValue, propertyValue);
                    }

                    objValue = propertyValue;
                }
            }

            var finalProperty = objValue.GetType().GetProperty(properties.Last());
            if (finalProperty == null)
                throw new ArgumentException($"Property {properties.Last()} not found.");

            finalProperty.SetValue(objValue, value);
        }
    }
}
