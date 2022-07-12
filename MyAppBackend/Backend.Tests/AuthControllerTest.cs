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
    public class AuthControllerTest
    {
        [Fact]
        public async Task Login()
        {
            //Arrange
            var user = A.Fake<LoginUser>();
            var response = A.Fake<AuthenticatedResponse>();
            var dataStore = A.Fake<IAuthService>();
            A.CallTo(() => dataStore.Login(user)).Returns(Task.FromResult(response));
            AuthController controller = new(dataStore);

            //Act
            IActionResult actionResult = await controller.Login(user);

            //Assert
            var objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(200, objectResponse.StatusCode);
        }

        [Fact]
        public async Task Register()
        {
            //Arrange
            var user = A.Fake<User>();
            var dataStore = A.Fake<IAuthService>();
            A.CallTo(() => dataStore.Register(user)).Returns(Task.FromResult(false));
            AuthController controller = new(dataStore);

            //Act
            IActionResult actionResult = await controller.Register(user);

            //Assert
            var objectResponse = Assert.IsType<ObjectResult>(actionResult);
            Assert.Equal(409, objectResponse.StatusCode);
        }
    }
}
