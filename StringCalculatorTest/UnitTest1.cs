using System;
using Xunit;
using StringCalculator;

namespace StringCalculatorTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("0,2,3", 5)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,0", 3)]
        [InlineData("0,0,0", 0)]
        [InlineData("1", 1)]
        [InlineData("", 0)]
        //[InlineData("1,2,-3", )]   //negatives not allowed, not sure how to test here
        [InlineData("5,10,1001",15)] //above 1000 don't count
        public void TestAdd(string numbers, int expected)
        {
            int actual = Program.Add(numbers);
            Assert.Equal(expected, actual);
        }
    }
}
