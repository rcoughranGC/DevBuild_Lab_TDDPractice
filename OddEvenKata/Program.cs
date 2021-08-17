using System;

namespace OddEvenKata
{
    public class Program
    {
        public static string EvenOrOdd(int num)
        {
            // For numbers that are even, print "EVEN"
            // For numbers that are odd, print "ODD"
            
            if (num == 2)      
                return "PRIME"; // Hardcode the only anomalous even number


            if (num % 2 == 0)
            {
                return "EVEN";
            }
            else
            {
                return "ODD";
            }
        }
        public static string IsPrime(int oddNum) //Stolen from Antonio, makes mine from yesterday look ridiculous
        {
            if (oddNum == 1)
                return "ODD"; // Harcode the only anomalous odd number


            // Pass only odds into this method for prime check
            for (int i = 3; i < oddNum; i++)
            {
                if (oddNum % i == 0)
                {
                    return "ODD";
                }
            }
            return "PRIME";
        }

        static void Main(string[] args)
        {
            // Write a program that prints the numbers from 1 to 100
            // For numbers that are even, print "EVEN"
            // For numbers that are odd, print "ODD".
            // For numbers that are prime(only divisible by 1 and itself), print "PRIME"

            for (int i = 1; i <= 100; i++)
            {
                if (EvenOrOdd(i) == "ODD") //Perform the prime check on odd numbers
                {
                    Console.WriteLine($"{i}: {IsPrime(i)}");
                }
                else
                {
                    Console.WriteLine($"{i}: {EvenOrOdd(i)}");
                }
                // I really wanted to create a single method for all this, 
                // but fought my brain to split it into two for the testing...
                // Which made it feel weird dealing with 1 and 2 as two special
                // cases across two different methods.
                // It would feel more natural to send all numbers into 1 method with 3 possible outputs.
                       
            }
        }
    }
}
