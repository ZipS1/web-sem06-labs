using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to convert: ");
            string input = Console.ReadLine();
            bool isOk = int.TryParse(input, out int result);
            if (isOk)
            {
                Console.WriteLine($"Result: {IntToBinary(result)}");
            } else
            {
                Console.WriteLine("Not a valid number to convert!");
            }
            Console.ReadKey();
        }

        public static string IntToBinary(int num)
        {
            int[] gaps = { 7, 15, 23 };
            StringBuilder binary = new StringBuilder();
            while (num > 0)
            {
                binary.Append(num & 1);
                num >>= 1;

                if (gaps.Contains(binary.Length))
                    binary.Append(' ');
            }

            return new string(binary.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}
