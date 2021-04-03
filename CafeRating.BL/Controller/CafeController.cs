using CafeRating.BL.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CafeRating.BL.Controller
{
    public class CafeController : BaseController
    {
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public readonly User CurrentUser;

        /// <summary>
        /// Список кофеень.
        /// </summary>
        public IEnumerable<Cafe> Cafes = new List<Cafe>
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
            CurrentUser = currentUser ?? throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(currentUser));
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
            #region Проверка
            if (cafe is null)
            {
                throw new ArgumentNullException($"{nameof(cafe)} не может быть null", nameof(cafe));
            }

            if (userComment is null)
            {
                throw new ArgumentNullException($"{nameof(userComment)} не может быть null", nameof(userComment));
            }
            #endregion

            cafe.Comments = GetComments(cafe);
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

        public void SetRating(Cafe cafe)
        {
            cafe.Comments = GetComments(cafe);
            if (cafe.Comments != null)
            {
                var rating = 0;
                foreach (var item in cafe.Comments)
                {
                    rating += item.Rating;
                }
                cafe.Rating = rating / cafe.Comments.Count;
            }
        }

        public double GetRating(Cafe cafe)
        {
            SetRating(cafe);
            return cafe.Rating;
        }
    }
}
