using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    internal class Program
    {
        public enum Gender
        {
            Male,
            Female
        }

        /*
            Создать консольное приложение на языке C# в соответствии со следующими требованиями:
                + Поля структуры являются приватными.
                +? Создать в структуре конструктор с параметрами. Имена параметров конструктора должны совпадать с именами полей структуры.
                + Реализовать в структуре метод вывода приватных полей на экран.
                + Реализовать в структуре решение задачи (вывод данных, соответствующих запросу) в виде метода.
                    Задача: Вычислить средние зарплаты у мужчин и женщин.      
                + Объявить в методе Main список (List) элементов структуры.
                - Организовать ввод данных пользователем. Данные вводятся с консоли по одной структуре за один раз и при вводе проверяются на допустимость (числа, даты и т.д.).
                - Пользователь может чередовать ввод данных в список и вывод данных, соответствующих запросу.
         */

        public struct Person
        {
            public string Name { get; private set; }
            public Gender Gender 
            { 
                get
                {
                    return _gender;
                    //return _gender == Program.Gender.Male ?
                    //    "Мужчина" :
                    //    "Женщина";
                }
            }
            private Gender _gender;
            public uint Salary { get; private set; }

            public Person(string name, bool isMale, uint salary)
            {
                Name = name;

                // Имена параметров конструктора должны совпадать с именами полей структуры.
                // Так можно? (Не нужно делать валидацию данных)
                _gender = isMale ? Gender.Male : Gender.Female;
                Salary = salary;
            }

            public static Tuple<double, double> getAverageSalaryByGender(List<Person> persons)
            {
                double maleAverage = persons.Where(x => x.Gender == Gender.Male).Sum(x => x.Salary);
                double femaleAverage = persons.Where(x => x.Gender == Gender.Female).Sum(x => x.Salary);
                return Tuple.Create(maleAverage , femaleAverage);
            }
        }

        public class Menu
        {
            private List<Person> persons = new List<Person>();

            public void Run()
            {
                bool isRunning = true;
                while (isRunning)
                {
                    ShowMenu();
                    ConsoleKey key = GetInput();
                    Console.Write("\n\n");

                    switch (key)
                    {
                        case ConsoleKey.D1:
                            Person? person = HandlePersonInput();
                            if (person is null)
                                Console.WriteLine("Неверно введены данные человека!");
                            else
                                persons.Add(person.Value);
                            break;
                        case ConsoleKey.D2:
                            HandlePersonsOutput();
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Выход...");
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Нажата неизвестная клавиша!");
                            break;
                    }
                }
            }

            private void ShowMenu()
            {
                Console.WriteLine("1 - Ввести");
                Console.WriteLine("2 - Вывести");
                Console.WriteLine("3 - Выход");
                Console.Write(">> ");
            }

            private ConsoleKey GetInput()
            {
                return Console.ReadKey().Key;
            }

            private Person? HandlePersonInput()
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите пол (м, ж): ");
                Gender? gender = ValidateGenderInput(Console.ReadLine());
                if (gender is null)
                    return null;

                Console.Write("Введите зарплату: ");
                if (uint.TryParse(Console.ReadLine(), out uint salary) == false)
                    return null;

                return new Person(name, gender == Gender.Male, salary);
            }

            private Gender? ValidateGenderInput(string input)
            {
                if (input == "м")
                    return Gender.Male;
                else if (input == "ж")
                    return Gender.Female;
                else
                    return null;
            }

            private void HandlePersonsOutput()
            {
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Имя: {person.Name}");
                    Console.WriteLine($"Пол: {person.Gender}");
                    Console.WriteLine($"Зарплата: {person.Salary}");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
