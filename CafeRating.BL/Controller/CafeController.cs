using CafeRating.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeRating.BL.Controller
{
    public class CafeController : BaseController
    {
        /// <summary>
        /// Список кофеень.
        /// </summary>
        public List<Cafe> Cafes = new List<Cafe>
        {
            new Cafe("Mak dak"),
            new Cafe("Black kWhite"),
            new Cafe("KFT"),
            new Cafe("У Ержана"),
            new Cafe("Пельмешоты")
        };

        public void AddComment(User user, string cafeName, int rating, string userComment)
        {
            // TODO: Сделать проверку.

            var comment = new UserComment(user, cafeName, rating, userComment);
            var cafe = Cafes.First(c => c.Name == cafeName);
            cafe.Comments.Add(comment);
            Save($"{cafe.Name}.dat", cafe.Comments);
        }
    }
}
