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
        public IEnumerable<Cafe> Cafes { get; private set; }

        private Dictionary<Cafe, double> RatingCafes { get; set; }

        /// <summary>
        /// Создать контроллер.
        /// </summary>
        /// <param name="currentUser"> Пользователь. </param>
        public CafeController(User currentUser)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(currentUser));
        
            Cafes = new List<Cafe>
            {
                new Cafe("Mak dak"),
                new Cafe("BlackWhite"),
                new Cafe("KFT"),
                new Cafe("У Ержана"),
                new Cafe("Пельмешоты")
            };
            RatingCafes = new Dictionary<Cafe, double>();
        }

        /// <summary>
        /// Получить кафе с таким названием.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        /// <returns> Кафе или null, если такого нет. </returns>
        public Cafe GetCafe(string cafeName)
        {
            if (string.IsNullOrWhiteSpace(cafeName))
            {
                throw new ArgumentException($"{nameof(cafeName)} не может быть пустым или содержать только пробел", nameof(cafeName));
            }

            return Cafes.FirstOrDefault(c => c.Name == cafeName);
        }

        /// <summary>
        /// Получить все комментарии.
        /// </summary>
        /// <param name="cafeName"> Название кафе. </param>
        /// <returns> Список комментариев </returns>
        public List<UserComment> GetComments()
        {
            var comments = Load<UserComment>();
            return (comments != null) ? comments : new List<UserComment>();
        }

        /// <summary>
        /// Добавить комментарий.
        /// </summary>
        /// <param name="cafe"> Кафе. </param>
        /// <param name="userComment"> Комментарий. </param>
        public void AddComment(UserComment userComment)
        {
            #region Проверка
            if (userComment == null)
                throw new ArgumentNullException($"{nameof(userComment)} не может быть null", nameof(userComment));
            if (Cafes.FirstOrDefault(c => c.Name == userComment.CafeName) == null)
                throw new ArgumentException("Не существует кафе с таким названием", nameof(userComment.CafeName));
            #endregion

            var comments = GetComments();
            var oldComment = comments.SingleOrDefault(c => c.User.Name == CurrentUser.Name);
            if (oldComment != null)
                comments.Remove(oldComment);

            comments.Add(userComment);
            Save(comments);
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

            var comments = GetComments();
            var comment = comments.SingleOrDefault(c => c.User.Name == CurrentUser.Name && c.CafeName == cafe.Name);
            if (comment == null)
                return false;
            else
                comments.Remove(comment);
            Save(comments);
            return true;
        }

        /// <summary>
        /// Установить рейтинг кафе.
        /// </summary>
        /// <param name="cafe"> Кафе. </param>
        private void SetRating(Cafe cafe)
        {
            var comments = GetComments().Where(c => c.CafeName == cafe.Name);
            double rating = 0;
            if (comments.Count() > 0)
            {
                foreach (var userComment in comments)
                {
                    rating += userComment.Rating;
                }
                RatingCafes[cafe] = rating / comments.Count();
            }
            else
            {
                RatingCafes[cafe] = rating;
            }
        }

        /// <summary>
        /// Получить рейтинг кафе.
        /// </summary>
        /// <param name="cafe"> Кафе. </param>
        /// <returns> Рейтинг кафе </returns>
        public double GetRating(Cafe cafe)
        {
            SetRating(cafe);
            return RatingCafes[cafe];
        }
    }
}
