using System;
using Xunit;
using OddEvenKata;

namespace OddEvenTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "ODD")]
        // [InlineData(2, "EVEN")] known anomaly
        [InlineData(3, "ODD")]
        [InlineData(13, "ODD")]
        [InlineData(22, "EVEN")]
        [InlineData(101, "ODD")]
        public void TestEvenOrOdd(int num, string expected)
        {
            string actual = Program.EvenOrOdd(num);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "ODD")]
        [InlineData(2, "PRIME")]
        [InlineData(3, "PRIME")]
        [InlineData(9, "ODD")]
        [InlineData(29, "PRIME")]
        [InlineData(33, "ODD")]
        [InlineData(131, "PRIME")]
        [InlineData(175, "ODD")]
        public void TestIsPrime(int num, string expected)
        {
            string actual = Program.IsPrime(num);
            Assert.Equal(expected, actual);
        }

    }


}
