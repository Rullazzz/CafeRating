using System;

namespace CafeRating.BL.Model
{
    [Serializable]
    public class UserComment
    {
        #region Свойства
        public string CafeName { get; }

        /// <summary>
        /// Оценка кафе.
        /// </summary>
        public int Rating { get; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Автор комментария.
        /// </summary>
        public User User { get; }
        #endregion

        /// <summary>
        /// Создать новый комментарий.
        /// </summary>
        /// <param name="nameCafe"> Название кафе. </param>
        /// <param name="rating"> Оценка кафе. </param>
        /// <param name="comment"> Комментарий. </param>
        public UserComment(User user, string cafeName, int rating, string comment)
        {
            if (string.IsNullOrWhiteSpace(cafeName))
            {
                throw new ArgumentException($"{nameof(cafeName)} не может быть пустым или содержать только пробел", nameof(cafeName));
            }

            User = user ?? throw new ArgumentNullException(nameof(user));
            CafeName = cafeName;
            Rating = rating;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public override string ToString()
        {
            return $"{User} ставит оценку {Rating}: {Comment}";
        }
    }
}
