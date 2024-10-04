namespace Spoleto.Delivery.Providers.Cdek
{
    internal record AdditionalServiceParameterInfo
    {
        public AdditionalServiceParameterInfo(string? parameterDescription, ParameterType? parameterType)
        {
            ParameterDescription = parameterDescription;
            ParameterType = parameterType;
        }

        public string? ParameterDescription { get; }

        public ParameterType? ParameterType { get; }
    }
}
