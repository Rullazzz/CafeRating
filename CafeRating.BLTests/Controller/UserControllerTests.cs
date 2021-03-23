using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeRating.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRating.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDateTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "M";
            var birthDay = DateTime.Now;

            // Act
            var userController = new UserController(userName);
            userController.SetNewUserDate(gender, birthDay);
            userController.Save();
            var userController2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userController.CurrentUser.Name, userController2.CurrentUser.Name);
            Assert.AreEqual(userController.CurrentUser.Gender, userController2.CurrentUser.Gender);
            Assert.AreEqual(userController.CurrentUser.BirthDate, userController2.CurrentUser.BirthDate);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var userController = new UserController(userName);
            var userController2 = new UserController(userName);

            // Assert
            Assert.AreNotEqual(userController.IsNewUser, userController2.IsNewUser);
        }
    }
}