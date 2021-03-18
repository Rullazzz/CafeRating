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

            //TODO: Сделать проверки на входные данные.
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate);
            userController.Save();
        }
    }
}
