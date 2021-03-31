using CafeRating.BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeRating.BL.Controller
{
    public class CafeController : BaseController
    {
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
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

        /// <summary>
        /// Создать контроллер.
        /// </summary>
        /// <param name="currentUser"> Пользователь. </param>
        public CafeController(User currentUser)
        {
            // TODO: Проверка.
            CurrentUser = currentUser;
        }

        public List<UserComment> GetComments(Cafe cafe)
        {
            return Load<List<UserComment>>($"{cafe.Name}.dat");
        }

        /// <summary>
        /// Добавить комментарий.
        /// </summary>
        /// <param name="cafe"> Кафе. </param>
        /// <param name="userComment"> Комментарий. </param>
        public void AddComment(Cafe cafe, UserComment userComment)
        {
            // TODO: Сделать проверку.
            cafe.Comments = Load<List<UserComment>>($"{cafe.Name}.dat");
            if (cafe.Comments == null)
                cafe.Comments = new List<UserComment>();

            cafe.Comments.Add(userComment);
            Save($"{cafe.Name}.dat", cafe.Comments);
        }

        /// <summary>
        /// Удалить комментарий.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        public void DeleteComment(string cafeName)
        {
            var cafe = Cafes.First(c => c.Name == cafeName);
            cafe.Comments.Remove(cafe.Comments.Find(c => c.Author == CurrentUser));
            Save($"{cafe.Name}.dat", cafe.Comments);
        }
    }
}
