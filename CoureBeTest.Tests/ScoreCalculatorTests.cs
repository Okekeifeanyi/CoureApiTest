using Xunit;
using CoureBeTest.Utilities; 

namespace CoureBeTest.Tests
{
    public class ScoreCalculatorTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 11)]
        [InlineData(new int[] { 15, 25, 35 }, 9)]
        [InlineData(new int[] { 8, 8 }, 12)]
        public void CalculateScore_ReturnsCorrectScore(int[] input, int expected)
        {
  
            var result = ScoreCalculator.CalculateScore(input);

            Assert.Equal(expected, result);
        }
    }
}
