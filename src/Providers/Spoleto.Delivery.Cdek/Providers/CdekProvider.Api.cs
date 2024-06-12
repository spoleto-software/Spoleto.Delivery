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
                var description = enumValue.GetDescription();
                var parameterType = GetAdditionalServiceParameterType(enumValue);

                if (code != null && name != null)
                {
                    var additionalService = new Delivery.AdditionalService { Code = code, Name = name, Description = description };
                    if (parameterType != null)
                    {
                        additionalService.ParameterType = parameterType;
                    }

                    list.Add(additionalService);
                }
            }

            return list;
        }

        private ParameterType? GetAdditionalServiceParameterType(AdditionalServiceType enumValue)
        {
            if (enumValue == AdditionalServiceType.BubbleWrap
                || enumValue == AdditionalServiceType.WastePaper)
                return ParameterType.Number;

            if (enumValue == AdditionalServiceType.Insurance)
                return ParameterType.Number;

            if (enumValue.ToString().StartsWith("CartonBox", StringComparison.Ordinal)
                || enumValue == AdditionalServiceType.CartonFiller)
                return ParameterType.Int;

            if (enumValue == AdditionalServiceType.Sms)
                return ParameterType.String;

            if (enumValue == AdditionalServiceType.PhotoOfDocuments)
                return ParameterType.String;

            return null;
        }
    }
}
