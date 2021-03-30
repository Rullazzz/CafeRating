using System;
using System.Collections.Generic;

namespace CafeRating.BL.Model
{
    public class Cafe
    {
        /// <summary>
        /// Название кафе.
        /// </summary>
        public string Name { get; }

        public List<UserComment> Comments { get; set; }

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
