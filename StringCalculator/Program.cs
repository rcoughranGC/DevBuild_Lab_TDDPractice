using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Program
    {
        public static int Add(string numbers)
        {
            int result = 0;

            //not messing with delimiters other than ","
            string[] numsToAdd = numbers.Split(',');
            List<int> negativesCaught = new List<int>();
            bool negCaught = false;
            foreach (var num in numsToAdd)
            {
                int.TryParse(num, out int parsed);
                if (parsed < 0)
                {
                    negCaught = true;
                    negativesCaught.Add(parsed);
                }
                else if (parsed >1000)
                {
                    parsed = 0;
                }
                else
                {
                    result += parsed;
                }
            }
            if (negCaught == true)
            {
                throw new NegativesNotAllowed(negativesCaught);
            }
            else
            return result;
        }
        public class NegativesNotAllowed : Exception
        {
            public NegativesNotAllowed(List<int> negatives) : base()
            {
                Console.Write("negatives not allowed: ");
                foreach (var negative in negatives)
                {
                    Console.Write(negative);
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("enter numbers");
            string entry = Console.ReadLine();
            Console.WriteLine(Add(entry));
        }
    }
}
