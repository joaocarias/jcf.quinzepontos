using Jcf.QuinzePontos.infrastructure.Extensions;

namespace Jcf.QuinzePontos.Tests.Infrastructure.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToUtcKind_Should_Return_Same_Date_When_Already_Utc()
        {
            // Arrange
            var date = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc);

            // Act
            var result = date.ToUtcKind();

            // Assert
            Assert.Equal(date, result);
            Assert.Equal(DateTimeKind.Utc, result.Kind);
        }

        [Fact]
        public void ToUtcKind_Should_Convert_Local_To_Utc()
        {
            // Arrange
            var localDate = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Local);

            // Act
            var result = localDate.ToUtcKind();

            // Assert
            Assert.Equal(DateTimeKind.Utc, result.Kind);
            Assert.Equal(localDate.ToUniversalTime(), result);
        }

        [Fact]
        public void ToUtcKind_Should_Set_Unspecified_To_Utc_Without_Changing_Time()
        {
            // Arrange
            var unspecifiedDate = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Unspecified);

            // Act
            var result = unspecifiedDate.ToUtcKind();

            // Assert
            Assert.Equal(DateTimeKind.Utc, result.Kind);
            Assert.Equal(unspecifiedDate.Year, result.Year);
            Assert.Equal(unspecifiedDate.Month, result.Month);
            Assert.Equal(unspecifiedDate.Day, result.Day);
            Assert.Equal(unspecifiedDate.Hour, result.Hour);
            Assert.Equal(unspecifiedDate.Minute, result.Minute);
            Assert.Equal(unspecifiedDate.Second, result.Second);
        }
    }
}
