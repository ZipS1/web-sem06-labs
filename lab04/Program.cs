using System;
using System.Collections.Generic;
using System.Linq;

namespace lab04
{
    public enum Gender
    {
        Male,
        Female
    }
    public static class GenderExtensions
    {
        public static string ToRussianString(this Gender gender)
        {
            return gender == Gender.Male ? "Мужской" : "Женский";
        }
    }

    public struct Person
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public uint Salary { get; private set; }

        public Person(string name, Gender gender, uint salary)
        {
            Name = name;
            Gender = gender;
            Salary = salary;
        }

        public static Tuple<double, double> getAverageSalaryByGender(List<Person> persons)
        {
            if (persons.Count == 0) 
                return Tuple.Create(.0, .0);

            double maleAverage = persons
                .Where(x => x.Gender == Gender.Male)
                .DefaultIfEmpty(new Person("Jack", Gender.Male, 0)) // uint collection cant use Average, also cant use parameterless constructors
                .Average(x => x.Salary);

            double femaleAverage = persons.
                Where(x => x.Gender == Gender.Female)
                .DefaultIfEmpty(new Person("Jack", Gender.Male, 0))
                .Average(x => x.Salary);
            return Tuple.Create(maleAverage, femaleAverage);
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
                        {
                            persons.Add(person.Value);
                            Console.WriteLine("Данные введены успешно!");
                        }
                        break;
                    case ConsoleKey.D2:
                        HandlePersonsOutput();
                        break;
                    case ConsoleKey.D3:
                        HandleAverageOutput();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Выход...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Нажата неизвестная клавиша!");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("1 - Ввести");
            Console.WriteLine("2 - Вывести");
            Console.WriteLine("3 - Посчитать среднюю");
            Console.WriteLine("4 - Выход");
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
            if (string.IsNullOrWhiteSpace(name))
                return null;

            Console.Write("Введите пол (м, ж): ");
            Gender? gender = ValidateGenderInput(Console.ReadLine());
            if (gender is null)
                return null;

            Console.Write("Введите зарплату: ");
            if (uint.TryParse(Console.ReadLine(), out uint salary) == false)
                return null;

            return new Person(name, gender.Value, salary);
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
            if (persons.Count == 0)
            {
                Console.WriteLine("Нет данных!");
                return;
            }    

            foreach (Person person in persons)
            {
                Console.WriteLine($"Имя: {person.Name}");
                Console.WriteLine($"Пол: {person.Gender.ToRussianString()}");
                Console.WriteLine($"Зарплата: {person.Salary}");
            }
        }

        private void HandleAverageOutput()
        {
            var averages = Person.getAverageSalaryByGender(persons);
            Console.WriteLine($"Среднее у мужчин: {averages.Item1}");
            Console.WriteLine($"Среднее у женщин: {averages.Item2}");
        }
    }

    internal class Program
    {
        /*
            Создать консольное приложение на языке C# в соответствии со следующими требованиями:
                + Поля структуры являются приватными.
                +? Создать в структуре конструктор с параметрами. Имена параметров конструктора должны совпадать с именами полей структуры.
                + Реализовать в структуре метод вывода приватных полей на экран.
                + Реализовать в структуре решение задачи (вывод данных, соответствующих запросу) в виде метода.
                    Задача: Вычислить средние зарплаты у мужчин и женщин.      
                + Объявить в методе Main список (List) элементов структуры.
                + Организовать ввод данных пользователем. Данные вводятся с консоли по одной структуре за один раз и при вводе проверяются на допустимость (числа, даты и т.д.).
                + Пользователь может чередовать ввод данных в список и вывод данных, соответствующих запросу.
         */

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
