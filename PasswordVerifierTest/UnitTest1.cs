using System;
using Xunit;
using PasswordVerifier;

namespace PasswordVerifierTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("password", false)]
        [InlineData("password123", false)]
        [InlineData("Password", false)]
        [InlineData("Password1", true)]
        [InlineData("pass", false)]
        [InlineData("Pass123", false)]
        [InlineData("Pa1", false)]
        [InlineData("PASSWORD123", true)]
        [InlineData("pa", false)]
        [InlineData("   ", false)]
        [InlineData("PasswordP", true)]
        [InlineData("password1234", true)]
        public void TestVerify(string password, bool expected)
        {
            bool actual = PasswordVerify.Verify(password);
            Assert.Equal(expected, actual);
        }
    }
}
