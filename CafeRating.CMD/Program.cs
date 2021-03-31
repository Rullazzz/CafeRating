using System;
using CafeRating.BL.Controller;
using System.Linq;
using CafeRating.BL.Model;
using System.Collections.Generic;

namespace CafeRating.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
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

            //Console.Write("Вы хотите оставить отзыв о кафе? (да или нет) ");

            DisplayCommands();
            bool isAlive = true;
            while (isAlive)
            {
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "help":
                        DisplayCommands();
                        break;
                    case "comment":
                        // TODO: написать добавление комментария.
                        AddComment(cafeController, userController.CurrentUser);
                        break;
                    case "exit":
                        isAlive = false; 
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда!");
                        break;
                }
            }            
            Console.ReadLine();
        }

        private static void AddComment(CafeController cafeController, User user)
        {
            Console.WriteLine("О каком кафе хотите оставить свой отзыв?");
            foreach (var _cafe in cafeController.Cafes)
                Console.WriteLine(_cafe);

            var choice = Console.ReadLine();
            var cafe = cafeController.Cafes.FirstOrDefault(c => c.Name == choice);
            // TODO: Написать проверки.
            if (cafe != null)
            {
                Console.Write("Ваша оценка данного кафе от 1 до 5: ");
                var rating = Console.ReadLine();

                Console.Write("Введите свой комментарий: ");
                var comment = Console.ReadLine();

                var userComment = new UserComment(user, cafe.Name, Int32.Parse(rating), comment);
                cafeController.AddComment(cafe, userComment);
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
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
            return birthDate;
        }

        private static void DisplayCommands()
        {
            var commands = new string[]
            {
                "help", // Вывод всех команд.
                "comment", // Оставить комментарий какому-либо кафе.
                "exit", // Выйти из приложения
            };
            foreach (var com in commands)
                Console.WriteLine(com);
        }
    }
}
