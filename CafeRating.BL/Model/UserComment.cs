using System;

namespace CafeRating.BL.Model
{
    [Serializable]
    public class UserComment
    {
        /// <summary>
        /// Название кафе.
        /// </summary>
        public string CafeName { get; set; }

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
        public User Author { get; }

        /// <summary>
        /// Создать новый комментарий.
        /// </summary>
        /// <param name="nameCafe"> Название кафе. </param>
        /// <param name="rating"> Оценка кафе. </param>
        /// <param name="comment"> Комментарий. </param>
        public UserComment(User user, string cafeName, int rating, string comment)
        {
            //TODO: Проверка

            CafeName = cafeName;
            Author = user;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"{Author.Name} ставит оценку {Rating}: {Comment}";
        }
    }
}
