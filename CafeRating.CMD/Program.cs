using System;
using CafeRating.BL.Controller;
using CafeRating.BL.Model;

namespace CafeRating.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CafeRating!");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDate();

                userController.SetNewUserDate(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);
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
