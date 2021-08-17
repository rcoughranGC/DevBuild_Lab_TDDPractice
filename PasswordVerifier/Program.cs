using System;

namespace PasswordVerifier
{
    public class PasswordVerify
    {

       // This is a work in progress. My tests are not all passing.
       // I'm still working on this (this practice is really helping)...
       // but want to push the
       // Solution up. The OddEvenKata should be good to go.







        public static bool Verify(string password)
        {
            //string tooShort = "Must be 9 or more characters.";
            //string isNull = "Please enter a password";
            //string needsUpper = "Must contain at least 1 uppercase letter.";
            //string needsLower = "Must contain at least on lowercase letter.";
            //string needsNum = "Must contain at least one number.";

            int tooShortCheck = password.Length > 8 ? 1 : 0;
            int notNullCheck = !String.IsNullOrWhiteSpace(password) ? 1 : 0;
            int hasUpperCheck = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    hasUpperCheck = 1;
                    break;
                }
            }
            int hasLowerCheck = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                {
                    hasLowerCheck = 1;
                    break;
                }
            }
            int hasNumCheck = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    hasNumCheck = 1;
                    break;
                }
            }

            int first3MustPass2 = (tooShortCheck + notNullCheck + hasUpperCheck);
            if (first3MustPass2 < 2)
            {
                return false;
            }
            if (first3MustPass2 + hasLowerCheck + hasNumCheck > 4)
            {
                return true;
            }
            else return false;
            
        }


    }
    public class Program
    {
        


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
