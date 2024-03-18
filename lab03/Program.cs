using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab03
{
    internal class Program
    {
        /*
         Сформировать одномерный массив как столбец матрицы, содержащий минимальный элемент на побочной диагонали.
         */
        static void Main(string[] args)
        {
            GetMatrixSize(args, out int x, out int y);
            List<List<int>> matrix = GenerateMatrix(x, y);
            OutputMatrix(matrix);

            FindMinElementColumn(matrix, out List<int> column);
            OutputArray(column);
            Console.ReadKey();
        }

        private static void GetMatrixSize(string[] args, out int x, out int y)
        {
            if (args.Length != 2)
                throw new ArgumentOutOfRangeException("Program should have 2 arguments");

            x = int.Parse(args[0]);
            y = int.Parse(args[1]);
        }

        private static List<List<int>> GenerateMatrix(int x, int y)
        {
            Random random = new Random();
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < y; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < x; j++)
                    row.Add(random.Next(-99, 99));
                matrix.Add(row);
            }
            return matrix;
        }

        private static void OutputMatrix(List<List<int>> matrix)
        {
            Console.WriteLine("--- Matrix ---");
            foreach (var row in matrix)
            {
                foreach (var el in row)
                {
                    Console.Write($"{el} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void OutputArray(List<int> array)
        {
            Console.WriteLine("--- Array ---");
            foreach (int el in array)
                Console.Write($"{el} ");
            Console.WriteLine();
        }

        /// <summary>
        /// Формирует одномерный массив как столбец матрицы, содержащий минимальный элемент на побочной диагонали.
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="column">Сформированный одномерный массив</param>
        private static void FindMinElementColumn(List<List<int>> matrix, out List<int> column)
        {
            column = new List<int>();

            List<int> sideDiagonal = GetSideDiagonal(matrix);
            int columnIndex = matrix[0].Count - sideDiagonal.IndexOf(sideDiagonal.Min()) - 1;
            column = matrix.Select(x => x[columnIndex]).ToList();
        }

        /// <summary>
        /// Returns side diagonal starting from the top right element
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>Side diagonal</returns>
        private static List<int> GetSideDiagonal(List<List<int>> matrix)
        {
            List<int> sideDiagonal = new List<int>();
            for (int i = 0; i < matrix.Count; i++)
            {
                int rowIndex = matrix[0].Count - i - 1;
                if (rowIndex < 0)
                    break;

                sideDiagonal.Add(matrix[i][rowIndex]);
            }
            return sideDiagonal;
        }
    }
}
