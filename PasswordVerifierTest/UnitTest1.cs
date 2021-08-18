using System;
using Xunit;
using PasswordVerifier;

namespace PasswordVerifierTest
{
    public class UnitTest1
    {
        //1.1 password should be larger than 8 chars
        //1.2 password should not be null
        //1.3 password should have one uppercase letter at least
        //1.4 password should have one lowercase letter at least
        //1.5 password should have one number at least

        /* "feature: Password is OK if at least three of the previous conditions is true"
        -What? Previous of/or including what? so "Pa" would be valid? 
         - its not null (1 condition)
         - its got an upper (2nd condition)
         - its got a lower (3rd condition)
        or Pa1 would be valid? 
        ...because its got the number condition in addition to those previous 3
        ...I've declined to implement this as written */
        
        //All conditions must be met

        [Theory]
        [InlineData("password", "135")]   //1.1, 1.3, 1.5 fail
        [InlineData("password123", "3")]  //1.3 fail
        [InlineData("Password", "15")]    //1.1, 1.5 fail
        [InlineData("Password1", "")]     //succeed
        [InlineData("pass", "135")]       //1.1, 1.3, 1.5 fail
        [InlineData("Pass123", "1")]      //1.1 fail 
        [InlineData("Pa1", "1")]          //1.1 fail
        [InlineData("PASSWORD123", "4")]  //1.4 fail
        [InlineData("pa", "135")]         //1.1, 1.3, 1.5 fail
        [InlineData(null, "12345")]       //all fail
        [InlineData("", "12345")]         //1.1, 1.2, 1.3, 1.4, 1.5 fail 
        [InlineData("          ", "345")] //1.3, 1.4, 1.5 fail
        [InlineData("PasswordP", "5")]    //1.5 fail
        [InlineData("password1234", "3")] //1.3 fail
        public void TestVerify(string password, string expected)
        {
            string actual = PasswordVerify.Verify(password);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "Password accepted")]
        [InlineData("234", "Password: \n - Cannot be blank" +
            "\n - Must contain at least one uppercase character" +
            "\n - Must contain at least one lowercase character")]
        [InlineData("345", "Password: \n - Must contain at least one uppercase character" +
            "\n - Must contain at least one lowercase character" +
            "\n - Must contain at least one number")]
        public void TestPasswordMessage(string errorcode, string expected)
        {
            string actual = PasswordVerify.PasswordMessage(errorcode);
            Assert.Equal(expected, actual);
        }
    }
}
