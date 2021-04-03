using System;
using CafeRating.BL.Controller;
using System.Linq;
using CafeRating.BL.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace CafeRating.CMD
{
    class Program
    {
        private static ConsoleColor ConsoleColorText = ConsoleColor.Green;
        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("");
        private static ResourceManager resourceManager = new ResourceManager("CafeRating.CMD.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColorText;
            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDate();

                userController.SetNewUserDate(gender, birthDate);
            }

            var cafeController = new CafeController(userController.CurrentUser);

            ShowCommands();
            while (true)
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
                        Environment.Exit(0);
                        break;
                    default:
                        ShowError(resourceManager.GetString("UnknownCommand", culture));
                        break;
                }
            }
        }

        private static void AddComment(CafeController cafeController, User user)
        {
            Console.WriteLine(resourceManager.GetString("WhichCafe", culture));
            foreach (var _cafe in cafeController.Cafes)
                Console.WriteLine("\t" + _cafe);

            var choice = Console.ReadLine();
            var cafe = cafeController.Cafes.FirstOrDefault(c => c.Name == choice);
            if (cafe != null)
            {
                Console.Write(resourceManager.GetString("EnterRating", culture));
                var rating = EnterRating();

                Console.Write(resourceManager.GetString("EnterComment", culture));
                var comment = Console.ReadLine();

                var userComment = new UserComment(user, rating, comment);
                cafeController.AddComment(cafe, userComment);
            }
            else
            {
                ShowError(resourceManager.GetString("ErrorDoesNotExistCafe", culture));
            }
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write(resourceManager.GetString("EnterDateTime", culture));
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    ShowError(resourceManager.GetString("ErrorInvalidDateOfBirthFormat", culture));
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
                    ShowError(resourceManager.GetString("ErrorInvalidInput", culture));
                }
            }
        }

        private static void ShowCommands()
        {
            var commands = new string[]
            {
                resourceManager.GetString("CommandHelp", culture), // Вывод всех команд.
                resourceManager.GetString("CommandComment", culture), // Оставить комментарий какому-либо кафе.
                resourceManager.GetString("CommandExit", culture), // Выйти из приложения
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
