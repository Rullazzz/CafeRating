using System;

namespace CafeRating.BL.Model
{
    public class UserComment
    {
        /// <summary>
        /// Кафе.
        /// </summary>
        public string NameCafe { get; }
        
        /// <summary>
        /// Оценка кафе.
        /// </summary>
        public double Rating { get; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Создать новый комментарий.
        /// </summary>
        /// <param name="nameCafe"> Название кафе. </param>
        /// <param name="rating"> Оценка кафе. </param>
        /// <param name="comment"> Комментарий. </param>
        public UserComment(string nameCafe, double rating, string comment)
        {
            //TODO: Проверка

            NameCafe = nameCafe;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString()
        {
            return NameCafe + Rating + Comment;
        }
    }
}
