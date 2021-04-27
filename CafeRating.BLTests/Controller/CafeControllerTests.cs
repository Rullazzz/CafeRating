using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CafeRating.BL.Model;

namespace CafeRating.BL.Controller.Tests
{
    [TestClass()]
    public class CafeControllerTests
    {
        [TestMethod()]
        public void AddCommentTest()
        {
            // Arrange
            var userName = "Патрик";
            var rnd = new Random();
            var user = new User(userName);
            var cafe = new Cafe("KFT");
            var userComment = new UserComment(user, cafe.Name, rnd.Next(1, 6), Guid.NewGuid().ToString());
            var cafeController = new CafeController(user);

            // Act
            cafeController.AddComment(userComment);

            // Assert
            Assert.IsTrue(cafeController.GetComments().SingleOrDefault(c => c.Comment == userComment.Comment) != null);
        }

        [TestMethod()]
        public void DeleteCommentTest()
        {
            // Arrange
            var userName = "Алекс";
            var rnd = new Random();
            var user = new User(userName);
            var cafeController = new CafeController(user);

            // Act
            var cafe = cafeController.GetCafe("BlackWhite");
            var userComment = new UserComment(user, cafe.Name, rnd.Next(1, 6), Guid.NewGuid().ToString());
            cafeController.AddComment(userComment);
            cafeController.DeleteComment(cafe);

            // Assert
            Assert.IsTrue(cafeController.GetComments().Where(c => c.CafeName == cafe.Name).Count() == 0);
        }
    }
}