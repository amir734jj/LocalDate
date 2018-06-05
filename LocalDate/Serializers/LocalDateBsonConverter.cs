using System;
using LocalDate.Constants;
using LocalDate.Factories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace LocalDate.Serializers
{
    public class LocalDateBsonConverter: SerializerBase<LocalDate> { 
        public override LocalDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var type = context.Reader.GetCurrentBsonType();

            return type != BsonType.String ? LocalDateConstants.ZeroLocalDate : LocalDateFactory.ParseLocalDate(context.Reader.ReadString());
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LocalDate localDate)
        {
            var bsonWriter = context.Writer;
            bsonWriter.WriteStartDocument();
            bsonWriter.WriteString(localDate.ToString());
            bsonWriter.WriteEndDocument();
        }
    }
}