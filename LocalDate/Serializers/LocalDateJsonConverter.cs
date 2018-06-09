using System;
using LocalDate.Constants;
using LocalDate.Factories;
using LocalDate.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LocalDate.Serializers
{
    public class LocalDateJsonConverter : JsonConverter
    {
        /// <summary>
        /// Custom serializer
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ILocalDateStruct localDateStruct)
            {
                JToken.FromObject(localDateStruct.ToString()).WriteTo(writer);
            }
        }

        /// <summary>
        /// Try to parse the LocalDate
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            var jValue = JToken.Load(reader).Value<string>();

            return string.IsNullOrEmpty(jValue) ? LocalDateConstants.ZeroLocalDate : LocalDateFactory.ParseLocalDate(jValue);
        }

        public override bool CanRead => true;

        public override bool CanConvert(Type objectType) => true;
    }
}