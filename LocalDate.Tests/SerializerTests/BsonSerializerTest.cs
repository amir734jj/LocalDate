using AutoFixture;
using LocalDate.Tests.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Xunit;

namespace LocalDate.Tests.SerializerTests
{
    public class BsonSerializerTest: LocalDateFixture
    {
        [Fact]
        public void Test__BsonCycle()
        {
            // Arrange
            var localDateObj = Fixture.Create<LocalDateWrapper>();
            
            // Act
            var result = BsonSerializer.Deserialize<LocalDateWrapper>(localDateObj.ToBsonDocument());
            
            // Assert
            Assert.Equal(localDateObj, result);
        }
    }
}