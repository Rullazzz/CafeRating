using System;

namespace CafeRating.BL.Model
{
    public class Cafe
    {
        /// <summary>
        /// Название кафе.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Средняя оценка кафе.
        /// </summary>
        public double AverageRating { get; set; }

        public override string ToString()
        {
            return Name + AverageRating;
        }
    }
}
