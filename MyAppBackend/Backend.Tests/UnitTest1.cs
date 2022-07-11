using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ApiModels;
using MyAppBackend.Controllers;
using MyAppBackend.Models;
using MyAppBackend.Services.Auth;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Login()
        {
            //Arrange
            LoginUser user = new() { Username = "", Password = "", Email = "", RememberMe = false };
            var response = A.Fake<AuthenticatedResponse>();
            var dataStore = A.Fake<IAuthService>();
            A.CallTo(() => dataStore.Login(user)).Returns(Task.FromResult(response));
            AuthController controller = new(dataStore);

            //Act
            IActionResult actionResult = await controller.Login(user);

            //Assert
            var objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(409, objectResponse.StatusCode);
        }

        [Fact]
        public async Task Register()
        {
            //Arrange
            User user = new() { Username = "", Password = "", Email = "" };
            bool flag = false;
            var dataStore = A.Fake<IAuthService>();
            A.CallTo(() => dataStore.Register(user)).Returns(Task.FromResult(flag));
            AuthController controller = new(dataStore);

            //Act
            IActionResult actionResult = await controller.Register(user);

            //Assert
            var objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(409, objectResponse.StatusCode);
        }
    }
}

