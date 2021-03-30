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

            //var commands = new List<string>()
            //{
            //    "help - Вывод команд",
            //    ""
            //};

            var cafeController = new CafeController(userController.CurrentUser);

            Console.Write("Вы хотите оставить отзыв о кафе? (да или нет) ");
            var choice = Console.ReadLine();

            if (choice == "да")
            {
                Console.WriteLine("О каком кафе хотите оставить свой отзыв?");
                foreach(var _cafe in cafeController.Cafes)
                    Console.WriteLine(_cafe);
                choice = Console.ReadLine();
                var cafe = cafeController.Cafes.FirstOrDefault(c => c.Name == choice);
                // TODO: Написать проверки.
                if (cafe != null)
                {
                    Console.Write("Ваша оценка данного кафе от 1 до 5: ");
                    var rating = Console.ReadLine();

                    Console.Write("Введите свой комментарий: ");
                    var comment = Console.ReadLine();

                    var userComment = new UserComment(userController.CurrentUser, cafe.Name, Int32.Parse(rating), comment);
                    cafeController.AddComment(cafe, userComment);
                }
            }
            Console.ReadLine();
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
    }
}
