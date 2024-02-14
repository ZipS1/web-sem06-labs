using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetMatrixSize(args, out int x, out int y);

            List<List<int>> matrix = InputMatrix(x, y);
            FindMinElementColumn(matrix, out List<int> column);

            Console.ReadKey();
        }

        private static void GetMatrixSize(string[] args, out int x, out int y)
        {
            if (args.Length != 2)
                throw new ArgumentOutOfRangeException("Program should have 2 arguments");

            x = int.Parse(args[0]);
            y = int.Parse(args[1]);
        }

        private static List<List<int>> InputMatrix(int x, int y)
        {
            List<List<int>> matrix = new List<List<int>>();

            Console.WriteLine($"Input matrix of {y} rows and {x} columns");
            for (int i = 0; i < y; i++)
            {
                Console.Write($"Row {i+1}: ");
                try
                {
                    matrix.Add(InputRow(x));
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return matrix;
        }

        private static List<int> InputRow(int x)
        {
            List<int> row = new List<int>();
            string input = Console.ReadLine();
            string[] splittedInput = input.Split(' ');
            if (splittedInput.Length != x)
                throw new ArgumentOutOfRangeException($"Elements amount not equal to {x}");

            foreach (string element in splittedInput)
            {
                try
                {
                    row.Add(int.Parse(element));
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return row;
        }

        private static void OutputArray(List<int> array)
        {
            Console.WriteLine("--- Array ---");
            foreach (int el in array)
                Console.Write($"{el} ");
            Console.WriteLine(array);
        }

        private static void FindMinElementColumn(List<List<int>> matrix, out List<int> column)
        {
            column = new List<int>();
        }
    }
}
