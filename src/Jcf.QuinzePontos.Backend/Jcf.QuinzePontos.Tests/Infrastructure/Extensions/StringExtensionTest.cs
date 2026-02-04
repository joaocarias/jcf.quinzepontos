using Jcf.QuinzePontos.Infrastructure.Extensions;

namespace Jcf.QuinzePontos.Tests.Infrastructure.Extensions
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData("(84) 99682-8298")]
        [InlineData("+55 (84) 99682-8298")]
        [InlineData("(84) 99682_8298")]
        [InlineData("056.845.451-84")]
        [InlineData("07/07/2023")]
        [InlineData("12 anos")]
        [InlineData("Joao 1827")]
        public void Only_Number_ReturnTrue(string str)
        {
            var onlyNumber = str.OnlyNumbers();
            _ = long.TryParse(onlyNumber, out long number);
            Assert.True(number > 0, $" {number} is a number");
        }

        [Theory]
        [InlineData("antonia fransicao")]
        [InlineData("antonio maria")]
        [InlineData("")]
        public void Only_Number_ReturnFalse(string str)
        {
            var onlyNumber = str.OnlyNumbers();
            _ = long.TryParse(onlyNumber, out long number);
            Assert.False(number > 0, $" {number} is not a number");
        }

        [Theory]
        [InlineData(null)]
        public void Only_Number_String_Null_ReturnNotNull(string str)
        {
            Assert.NotNull(str.OnlyNumbers());
        }

        [Theory]
        [InlineData("João Carias de França")]
        [InlineData("Messias Targino")]
        [InlineData("Ana Maria")]
        public void First_Part_More_Than_One_ReturnTrue(string str)
        {
            Assert.True(str.Length > str.FirstPart().Length, $" {str.FirstPart()} is first part");
        }

        [Theory]
        [InlineData("João")]
        [InlineData("Messias")]
        [InlineData("Ana")]
        public void First_Part_Only_One_ReturnTrue(string str)
        {
            Assert.True(str.Length.Equals(str.FirstPart().Length), $" {str.FirstPart()} is first part");
        }

        [Theory]
        [InlineData("abc", 2, true)]
        [InlineData("abc", 3, true)]
        [InlineData("abc", 4, false)]
        [InlineData("a", -5, true)]
        public void Min_ShouldReturnExpectedResult(string input, int min, bool expected)
        {
            var result = input.Min(min);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", 2, false)]
        [InlineData("abc", 3, true)]
        [InlineData("abc", 4, true)]
        [InlineData("abc", -1, true)]
        public void Max_ShouldReturnExpectedResult(string input, int max, bool expected)
        {
            var result = input.Max(max);
            Assert.Equal(expected, result);
        }
    }
}
