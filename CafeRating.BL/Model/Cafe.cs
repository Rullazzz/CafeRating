using System.Collections.Generic;

namespace CafeRating.BL.Model
{
    public class Cafe
    {
        /// <summary>
        /// Название кафе.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список комментариев кафе.
        /// </summary>
        public List<UserComment> Comments { get; set; }

        /// <summary>
        /// Рейтинг кафе.
        /// </summary>
        public double Rating
        {
            get
            {
                double rating = 0;
                if (Comments.Count > 0)
                {
                    foreach (var comment in Comments)
                        rating += comment.Rating;
                    return rating / Comments.Count;
                }
                return rating;
            }
        }

        /// <summary>
        /// Создать новое кафе.
        /// </summary>
        /// <param name="name"> Название кафе. </param>
        public Cafe(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
