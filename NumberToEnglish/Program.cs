using System;

namespace NumberToEnglish
{
    public class Program
    {
        public static string NumToWords(double number)
        {
            string num = number.ToString();
            string hundredths = "";

            //handle the decimal
            if (number % 1 != 0)
            {
                double dec = number % 1;
                hundredths += String.Format(dec.ToString(".00") + "/100");
                hundredths = hundredths.Replace('.', ' ');
            }
            if (num.Contains("."))
            {
                num = num.Remove(num.IndexOf("."));
            }
            int numOfDigits = num.Length;
           
            //And here is where I give up on this function
            //its hard to write tests for code that would take days to come up with
            //and recursion is really hard to grasp still.



            return num + hundredths;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            double input = double.Parse(Console.ReadLine());
            Console.WriteLine(NumToWords(input));
        }
    }
}
