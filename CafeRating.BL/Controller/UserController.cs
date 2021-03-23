using CafeRating.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CafeRating.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Возвращает true, если это новый пользователь, иначе false.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Имя пользователя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Установить новые данные пользователю.
        /// </summary>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        public void SetNewUserDate(string gender, DateTime birthDate)
        {
            //TODO: Проверка.

            CurrentUser.Gender = gender;
            CurrentUser.BirthDate = birthDate;
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns> Пользователи приложения. </returns>
        private List<User> GetUserData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
