using System;
using LocalDate.Constants;
using LocalDate.Factories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace LocalDate.Serializers
{
    public class LocalDateBsonConverter: SerializerBase<LocalDate>
    { 
        /// <summary>
        /// Parse the LocalDate from string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public override LocalDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var type = context.Reader.GetCurrentBsonType();

            return type != BsonType.String ? LocalDateConstants.ZeroLocalDate : LocalDateFactory.ParseLocalDate(context.Reader.ReadString());
        }

        /// <summary>
        /// ToString the LocalDate
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        /// <param name="localDate"></param>
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LocalDate localDate)
        {
            context.Writer.WriteString(localDate.ToString());
        }
    }
}