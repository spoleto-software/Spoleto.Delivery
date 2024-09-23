namespace Spoleto.Delivery.Providers.Cdek
{
    public partial class CdekProvider
    {
        private List<Delivery.AdditionalService> GetAdditionalServices()
        {
            var list = new List<Delivery.AdditionalService>();

            foreach (AdditionalServiceType enumValue in Enum.GetValues(typeof(AdditionalServiceType)))
            {
                var code = enumValue.GetJsonEnumValue();
                var name = enumValue.ToString();
                var description = enumValue.GetDescription()!;
                var (parameterDescription, parameterType) = GetAdditionalServiceParameterType(enumValue);

                if (code != null && name != null)
                {
                    var additionalService = new Delivery.AdditionalService { Code = name, Name = description };
                    if (parameterType != null)
                    {
                        additionalService.ParameterType = parameterType;
                        additionalService.Description = parameterDescription;
                    }

                    list.Add(additionalService);
                }
            }

            return list;
        }

        private (string ParameterDescription, ParameterType? ParameterType) GetAdditionalServiceParameterType(AdditionalServiceType enumValue)
        {
            if (enumValue == AdditionalServiceType.BubbleWrap
                || enumValue == AdditionalServiceType.WastePaper)
                return ("Параметр услуги: длина", ParameterType.Number);

            if (enumValue == AdditionalServiceType.Insurance)
                return ("Параметр услуги: объявленная стоимость заказа (только для заказов с типом \"Доставка\")", ParameterType.Number);

            if (enumValue.ToString().StartsWith("CartonBox", StringComparison.Ordinal)
                || enumValue == AdditionalServiceType.CartonFiller)
                return ("Параметр услуги: количество", ParameterType.Int);

            if (enumValue == AdditionalServiceType.Sms)
                return ("Параметр услуги: номер телефона", ParameterType.String);

            if (enumValue == AdditionalServiceType.PhotoOfDocuments)
                return ("Параметр услуги: код фотопроекта", ParameterType.String);

            return (null, null);
        }
    }
}
