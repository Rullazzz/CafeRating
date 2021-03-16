using System;

namespace CafeRating.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public string Gender { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        public User(string name, string gender, DateTime birthDate)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Пол не может быть пустым или null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
