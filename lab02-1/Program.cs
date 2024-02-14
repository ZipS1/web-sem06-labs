using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            foreach (var arg in args)
            {
                Console.Write($"{arg} ");
                bool isOk = int.TryParse(arg, out int result);
                if (isOk)
                    sum += result;
            }
            Console.WriteLine($"\nSum: {sum}");
            Console.ReadKey();
        }
    }
}
