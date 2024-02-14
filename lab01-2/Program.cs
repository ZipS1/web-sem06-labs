using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01_2
{
    /// <summary>
    /// Типы геометрических фигур
    /// </summary>
    enum Figure
    {
        Romb,
        Circle,
        Rect,
    };

    /// <summary>
    /// Данные о геометрической фигуре
    /// </summary>
    struct Fdata
    {
        /// <summary>
        /// Координаты центра тяжести
        /// </summary>
        public int x0, y0;

        /// <summary>
        /// Цвет фигуры
        /// </summary>
        public int color;

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public Figure type;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Fdata fd = new Fdata()
            {
                x0 = 1,
                y0 = 1,
                color = 0x2727FF,
                type = Figure.Romb,
            };

            Console.WriteLine(string.Format("Coordinates: x0 = {0}, y0 = {1}", fd.x0, fd.y0));
            Console.WriteLine(string.Format("Color: {0}", fd.color));
            Console.WriteLine(string.Format("Figure type: {0}", fd.type));
            Console.ReadKey();
        }
    }
}
