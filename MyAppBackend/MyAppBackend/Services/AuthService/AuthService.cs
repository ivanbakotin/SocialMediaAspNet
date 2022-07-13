using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.Utilities;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AuthenticatedResponse> Login(LoginUser user)
        {
            var userObject = await unitOfWork.Users.FindUser(user);

            if (userObject == null)
            {
                throw new Exception("Wrong email or password!");
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            if (hashedPassword != userObject.Password)
            {
                throw new Exception("Wrong email or password!");
            }

            string tokenString = CreateJwt.GetJwt(userObject.Role.Name, userObject.ID.ToString());

            if (user.RememberMe)
            {
                var session = new Session
                {
                    UserID = userObject.ID,
                    Jwt = tokenString
                };

                unitOfWork.Sessions.Add(session);
                unitOfWork.Save();
            }

            return new AuthenticatedResponse { Token = tokenString };
        }

        public async Task Register(User user)
        {
            var emailRegex = new Regex(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$");
            var passwordRegex = new Regex(@"(?=(.*[0-9]))((?=.*[A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z]))^.{8,}$");
            var usernameRegex = new Regex(@"^[a-z0-9_-]{3,16}$");

            if (!emailRegex.Match(user.Email).Success)
            {
                throw new Exception("Incorrect!");
            }

            if (!passwordRegex.Match(user.Password).Success)
            {
                throw new Exception("Incorrect!");
            }

            if (!usernameRegex.Match(user.Username).Success)
            {
                throw new Exception("Incorrect!");
            }

            bool userExists = await unitOfWork.Users.UserExists(user);

            if (userExists)
            {
                throw new Exception("Wrong email or password!");
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            User newUser = new()
            {
                Username = user.Username,
                Email = user.Email,
                Password = hashedPassword,
                RoleID = 2
            };

            unitOfWork.Users.Add(newUser);
            unitOfWork.Save();

            Profile newProfile = new() { UserID = newUser.ID };

            unitOfWork.Profiles.Add(newProfile);
            unitOfWork.Save();
        }

        public async Task<AuthenticatedResponse> IsLoggedIn(string token)
        {
            var session = await unitOfWork.Sessions.FindSession(token);

            if (session == null)
            {
                return null;
            }

            string tokenString = CreateJwt.GetJwt(session.User.Role.Name, session.User.ID.ToString());

            var newSession = new Session
            {
                UserID = session.UserID,
                Jwt = tokenString
            };

            unitOfWork.Sessions.Remove(session);
            unitOfWork.Sessions.Add(newSession);
            unitOfWork.Save();

            return new AuthenticatedResponse { Token = tokenString }; ;
        }

        public async Task Logout(int UserID)
        {
            var sessionToDelete = await unitOfWork.Sessions.FindAll(x => x.UserID == UserID);

            if (sessionToDelete != null)
            {
                unitOfWork.Sessions.RemoveRange(sessionToDelete);
                unitOfWork.Save();
            }
        }
    }
}
