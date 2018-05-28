using AutoFixture;
using LocalDate.Interfaces;
using Newtonsoft.Json;
using Xunit;

namespace LocalDate.Tests.SerializerTests
{
    public class JsonSerializerTest: LocalDateFixture
    {
        [Fact]
        public void Test__JsonSerialize()
        {
            // Arrange
            var localDate = Fixture.Create<LocalDate>();

            // Act
            var jToken = JsonConvert.SerializeObject(localDate);

            // Assert
            Assert.Equal(jToken, $"\"{localDate.ToString()}\"");
        }

        [Fact]
        public void Test__JsonDeserialize()
        {
            // Arrange
            var localDate = Fixture.Create<LocalDate>();

            // Act
            var result = JsonConvert.DeserializeObject<LocalDate>($"\"{localDate.ToString()}\"");

            // Assert
            Assert.Equal(localDate, result);
        }
    }
}