using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeRating.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var cafe = new Cafe("Прикол");
            var userComment = new UserComment(user, rnd.Next(1, 6), Guid.NewGuid().ToString());
            var cafeController = new CafeController(user);

            // Act
            cafeController.AddComment(cafe, userComment);

            // Assert
            Assert.IsTrue(cafeController.GetComments(cafe).SingleOrDefault(c => c.Comment == userComment.Comment) != null);
        }

        //[TestMethod()]
        //public void DeleteCommentTest()
        //{
        //    Assert.Fail();
        //}
    }
}