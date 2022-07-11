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
        public async Task Test1()
        {
            //Arrange
            LoginUser user = new() { Username = "ivan", Password = "1", Email = "ivan", RememberMe = false };
            var response = A.Fake<AuthenticatedResponse>();
            var dataStore = A.Fake<IAuthService>();
            A.CallTo(() => dataStore.Login(user)).Returns(Task.FromResult(response));
            AuthController controller = new(dataStore);

            //Act
            IActionResult actionResult = await controller.Login(user);

            //Assert
            var objectResponse = Assert.IsType<OkObjectResult>(actionResult);
            var tokenObject = objectResponse.Value as AuthenticatedResponse;
            Assert.NotNull(tokenObject.Token);
        }
    }
}

