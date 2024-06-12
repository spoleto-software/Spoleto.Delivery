using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.Delivery.Providers.Cdek
{
    [JsonConverter(typeof(JsonEnumValueConverter<RequestState>))]
    public enum RequestState
    {
        /// <summary>
        /// пройдена предварительная валидация и запрос принят.
        /// </summary>
        [JsonEnumValue("ACCEPTED")]
        Accepted,

        /// <summary>
        /// запрос ожидает обработки (зависит от выполнения другого запроса).
        /// </summary>
        [JsonEnumValue("WAITING")]
        Waiting,

        /// <summary>
        /// запрос обработан успешно.
        /// </summary>
        [JsonEnumValue("SUCCESSFUL")]
        Successful,

        /// <summary>
        /// запрос обработался с ошибкой.
        /// </summary>
        [JsonEnumValue("INVALID")]
        Invalid
    }
}
