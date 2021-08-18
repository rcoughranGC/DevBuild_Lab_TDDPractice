using System;

namespace PasswordVerifier
{
    public class PasswordVerify
    {
        public static string Verify(string password)
        {
            string errorCode = "";
            string lengthCheck;
            string nullCheck;
            string hasUpperCheck;
            string hasLowerCheck;
            string hasNumCheck;
            // We'll build an error code string in this method 
            // that we'll use in another method to output 
            // a message about the password:
            //1 password should be larger than 8 chars
            //2 password should not be null
            //3 password should have one uppercase letter at least
            //4 password should have one lowercase letter at least
            //5 password should have one number at least

            if (String.IsNullOrEmpty(password)) 
            {
                return "12345";  //all conditions fail
            }

            lengthCheck = password.Length > 8 ? "" : "1"; //length check

            nullCheck = ""; //not needed but added for structure

            hasUpperCheck = "3"; //send a 3 if no upper is found
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    hasUpperCheck = ""; //upper found, do not include in error code
                    break;
                }
            }

            hasLowerCheck = "4"; //send a 4 if no lower is found
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                {
                    hasLowerCheck = ""; //lower found, do not include in error code
                    break;
                }
            }

            hasNumCheck = "5"; //send a 5 if no number is found
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    hasNumCheck = ""; //number found, do not include in error code
                    break;
                }
            }
            //length, null, upper, lower, num - in that order
            errorCode += lengthCheck + nullCheck + hasUpperCheck + hasLowerCheck + hasNumCheck;
            return errorCode;
        }

        public static string PasswordMessage(string errorCode)
        {
            string output = "Password: ";
            if (errorCode == "") //no errors
            {
                output = "Password accepted";
            }
            if (errorCode.Contains("1")) //contained 8 or less characters
            {
                output += "\n - Must be 9 or more characters";
            }
            if (errorCode.Contains("2")) //was null
            {
                output += "\n - Cannot be blank";
            }
            if (errorCode.Contains("3")) //has no uppercase
            {
                output += "\n - Must contain at least one uppercase character";
            }
            if (errorCode.Contains("4"))
            {
                output += "\n - Must contain at least one lowercase character";
            }
            if (errorCode.Contains("5"))
            {
                output += "\n - Must contain at least one number";
            }
            
            return output;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            while (output != "Password accepted")
            {
                Console.WriteLine("Please enter a password");
                string password = Console.ReadLine();
                output = PasswordVerify.PasswordMessage(PasswordVerify.Verify(password));
                Console.WriteLine(output);
            }   
        }
    }
}
