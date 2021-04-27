using System;
using CafeRating.BL.Controller;
using System.Linq;
using CafeRating.BL.Model;
using System.Globalization;
using System.Resources;

namespace CafeRating.CMD
{
    class Program
    {
        private static ConsoleColor ConsoleColorText = ConsoleColor.Cyan;
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
                Console.Write(">> ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "help":
                        ShowCommands();
                        break;
                    case "comment":
                        AddComment(cafeController);
                        break;
                    case "delete":
                        DeleteComment(cafeController);
                        break;
                    case "cafes":
                        ShowCafes(cafeController);
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

        private static void DeleteComment(CafeController cafeController)
        {
            Console.WriteLine(resourceManager.GetString("ChooseCafe", culture));
            ShowCafes(cafeController);

            while (true)
            {
                var choice = Console.ReadLine();
                var cafe = cafeController.GetCafe(choice);
                if (cafe != null)
                {
                    var isDelete = cafeController.DeleteComment(cafe);
                    if (isDelete)
                        Console.WriteLine(resourceManager.GetString("DeleteSuccessfully"));
                    else
                        ShowError(resourceManager.GetString("NoComment"));
                    break;
                }
                else
                {
                    ShowError(resourceManager.GetString("ErrorDoesNotExistCafe", culture));
                }
            }
        }

        private static void AddComment(CafeController cafeController)
        {
            Console.WriteLine(resourceManager.GetString("ChooseCafe", culture));
            ShowCafes(cafeController);

            while (true)
            {
                var choice = Console.ReadLine();
                var cafe = cafeController.Cafes.FirstOrDefault(c => c.Name == choice);
                if (cafe != null)
                {
                    Console.Write(resourceManager.GetString("EnterRating", culture));
                    var rating = EnterRating();

                    Console.Write(resourceManager.GetString("EnterComment", culture));
                    var comment = Console.ReadLine();

                    var userComment = new UserComment(cafeController.CurrentUser, cafe.Name, rating, comment);
                    cafeController.AddComment(userComment);
                    break;
                }
                else
                {
                    ShowError(resourceManager.GetString("ErrorDoesNotExistCafe", culture));
                }
            }
            
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write(resourceManager.GetString("EnterDateTime", culture));
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    break;                
                else
                    ShowError(resourceManager.GetString("ErrorInvalidDateOfBirthFormat", culture));
            }
            return birthDate;
        }

        private static int EnterRating()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number >= 1 && number <= 5)
                    return number;
                else
                    ShowError(resourceManager.GetString("ErrorInvalidInput", culture));
            }
        }

        private static void ShowCommands()
        {
            var commands = new string[]
            {
                resourceManager.GetString("CommandHelp", culture), // Вывод всех команд.
                resourceManager.GetString("CommandComment", culture), // Оставить комментарий какому-либо кафе.
                resourceManager.GetString("CommandDelete", culture), // Удалить комментарий.
                resourceManager.GetString("CommandCafes", culture), // Показать все кафе.
                resourceManager.GetString("CommandExit", culture), // Выйти из приложения.
            };
            foreach (var com in commands)
                Console.WriteLine(com);
        }

        private static void ShowCafes(CafeController cafeController)
        {
            foreach (var cafe in cafeController.Cafes)
                Console.WriteLine("{0, 12} \t Средняя оценка: {1, 3} ({2} комментариев)", cafe.Name, cafeController.GetRating(cafe), cafeController.GetComments().Where(c => c.CafeName == cafe.Name).Count());
            
        }

        private static void ShowError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColorText;
        }
    }
}
