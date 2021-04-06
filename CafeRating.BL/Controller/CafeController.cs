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

        /// <summary>
        /// Получить кафе с таким названием.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        /// <returns> Кафе или null, если такого нет. </returns>
        public Cafe GetCafe(string cafeName)
        {
            return Cafes.FirstOrDefault(c => c.Name == cafeName);
        }

        /// <summary>
        /// Получить комментарии кафе из списка.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        /// <returns> Список комментариев </returns>
        public List<UserComment> GetComments(string cafeName)
        {
            #region Проверка
            if (cafeName == null)
                throw new ArgumentNullException(nameof(cafeName));
            if (Cafes.FirstOrDefault(c => c.Name == cafeName) == null)
                throw new ArgumentException("Не существует кафе с таким названием", nameof(cafeName));
            #endregion

            var comments = Load<List<UserComment>>($"{cafeName}.dat");
            return (comments != null) ? comments : new List<UserComment>();
        }

        /// <summary>
        /// Добавить комментарий.
        /// </summary>
        /// <param name="cafe"> Кафе. </param>
        /// <param name="userComment"> Комментарий. </param>
        public void AddComment(Cafe cafe, UserComment userComment)
        {
            #region Проверка
            if (cafe == null)
                throw new ArgumentNullException($"{nameof(cafe)} не может быть null", nameof(cafe));
            if (userComment == null)
                throw new ArgumentNullException($"{nameof(userComment)} не может быть null", nameof(userComment));
            if (Cafes.FirstOrDefault(c => c.Name == cafe.Name) == null)
                throw new ArgumentException("Не существует кафе с таким названием", nameof(cafe.Name));
            #endregion

            cafe.Comments = GetComments(cafe.Name);
            var oldComment = cafe.Comments.SingleOrDefault(c => c.Author.Name == CurrentUser.Name);
            if (oldComment != null)
                cafe.Comments.Remove(oldComment);

            cafe.Comments.Add(userComment);
            Save($"{cafe.Name}.dat", cafe.Comments);
        }

        /// <summary>
        /// Удалить комментарий.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        /// <returns> 
        /// Возвращает true, если комментарий успешно удален.
        /// Если комментария нет, то возвращает false.
        /// </returns>
        public bool DeleteComment(Cafe cafe)
        {
            #region Проверка
            if (cafe == null)
                throw new ArgumentNullException($"{nameof(cafe)} не может быть null", nameof(cafe));
            if (Cafes.FirstOrDefault(c => c.Name == cafe.Name) == null)
                throw new ArgumentException("Не существует кафе с таким названием", nameof(cafe.Name));
            #endregion

            var comment = cafe.Comments.SingleOrDefault(c => c.Author == CurrentUser);
            if (comment == null)
                return false;
            else
                cafe.Comments.Remove(comment);
            Save($"{cafe.Name}.dat", cafe.Comments);
            return true;
        }

        public void SetRating(Cafe cafe)
        {
            cafe.Comments = GetComments(cafe.Name);
            if (cafe.Comments.Count > 0)
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
