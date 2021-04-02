using System;
using CafeRating.BL.Controller;
using System.Linq;
using CafeRating.BL.Model;
using System.Collections.Generic;

namespace CafeRating.CMD
{
    class Program
    {
        public static ConsoleColor ConsoleColorText = ConsoleColor.Green;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColorText;
            Console.WriteLine("Вас приветствует приложение CafeRating!");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDate();

                userController.SetNewUserDate(gender, birthDate);
            }

            var cafeController = new CafeController(userController.CurrentUser);

            ShowCommands();
            bool isAlive = true;
            while (isAlive)
            {
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "help":
                        ShowCommands();
                        break;
                    case "comment":
                        AddComment(cafeController, userController.CurrentUser);
                        break;
                    case "exit":
                        isAlive = false; 
                        break;
                    default:
                        ShowError("Неизвестная команда!");
                        break;
                }
            }
            Console.Write("Программа завершена . . .");
            Console.ReadLine();
        }

        private static void AddComment(CafeController cafeController, User user)
        {
            Console.WriteLine("О каком кафе хотите оставить свой отзыв?");
            foreach (var _cafe in cafeController.Cafes)
                Console.WriteLine("\t" + _cafe);

            var choice = Console.ReadLine();
            var cafe = cafeController.Cafes.FirstOrDefault(c => c.Name == choice);
            if (cafe != null)
            {
                Console.Write("Ваша оценка данного кафе от 1 до 5: ");
                var rating = EnterRating();

                Console.Write("Введите свой комментарий: ");
                var comment = Console.ReadLine();

                var userComment = new UserComment(user, rating, comment);
                cafeController.AddComment(cafe, userComment);
            }
            else
            {
                ShowError("Такого кафе нет");
            }
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    ShowError("Неверный формат даты рождения");
                }
            }
            return birthDate;
        }

        private static int EnterRating()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number >= 1 && number <= 5)
                {
                    return number;
                }
                else
                {
                    ShowError("Неккоректный ввод");
                }
            }
        }

        private static void ShowCommands()
        {
            var commands = new string[]
            {
                "help - Вывод всех команд", // Вывод всех команд.
                "comment - Оставить комментарий какому-либо кафе", // Оставить комментарий какому-либо кафе.
                "exit - Выйти из приложения", // Выйти из приложения
            };
            foreach (var com in commands)
                Console.WriteLine(com);
        }

        private static void ShowError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColorText;
        }
    }
}
