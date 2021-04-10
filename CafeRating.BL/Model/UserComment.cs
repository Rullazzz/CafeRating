using System;

namespace CafeRating.BL.Model
{
    [Serializable]
    public class UserComment
    {
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
        public string Author { get; }

        /// <summary>
        /// Создать новый комментарий.
        /// </summary>
        /// <param name="nameCafe"> Название кафе. </param>
        /// <param name="rating"> Оценка кафе. </param>
        /// <param name="comment"> Комментарий. </param>
        public UserComment(string user, string cafeName, int rating, string comment)
        {
            if (string.IsNullOrWhiteSpace(cafeName))
            {
                throw new ArgumentException($"{nameof(cafeName)} не может быть пустым или содержать только пробел", nameof(cafeName));
            }

            Author = user ?? throw new ArgumentNullException(nameof(user));
            CafeName = cafeName;
            Rating = rating;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public override string ToString()
        {
            return $"{Author} ставит оценку {Rating}: {Comment}";
        }
    }
}
