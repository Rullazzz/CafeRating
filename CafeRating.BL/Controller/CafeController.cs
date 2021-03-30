using CafeRating.BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeRating.BL.Controller
{
    public class CafeController : BaseController
    {
        public User CurrentUser { get; }

        /// <summary>
        /// Список кофеень.
        /// </summary>
        public List<Cafe> Cafes = new List<Cafe>
        {
            new Cafe("Mak dak"),
            new Cafe("BlackWhite"),
            new Cafe("KFT"),
            new Cafe("У Ержана"),
            new Cafe("Пельмешоты")
        };

        public CafeController(User currentUser)
        {
            // TODO: Проверка.
            CurrentUser = currentUser;
        }

        public void AddComment(Cafe cafe, UserComment userComment)
        {
            // TODO: Сделать проверку.
            cafe.Comments = Load<List<UserComment>>($"{cafe.Name}.dat", cafe.Comments);
            if (cafe.Comments == null)
                cafe.Comments = new List<UserComment>();

            cafe.Comments.Add(userComment);
            Save($"{cafe.Name}.dat", cafe.Comments);
        }

        public void DeleteComment(string cafeName)
        {
            var cafe = Cafes.First(c => c.Name == cafeName);
            cafe.Comments.Remove(cafe.Comments.Find(c => c.Author == CurrentUser));
            Save($"{cafe.Name}.dat", cafe.Comments);
        }
    }
}
