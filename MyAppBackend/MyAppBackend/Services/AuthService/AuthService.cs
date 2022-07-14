using Microsoft.IdentityModel.Tokens;
using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

            string tokenString = CreateJwt(userObject.Role.Name, userObject.ID.ToString());

            if (user.RememberMe)
            {
                CreateSession(userObject.ID, tokenString);
                unitOfWork.Save();
            }

            return new AuthenticatedResponse { Token = tokenString };
        }

        public async Task Register(User user)
        {
            var emailRegex = new Regex(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$");
            var passwordRegex = new Regex(@"(?=(.*[0-9]))((?=.*[A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z]))^.{8,}$");
            var usernameRegex = new Regex(@"^[a-z0-9_-]{3,16}$");

            if (!emailRegex.Match(user.Email).Success || 
                !passwordRegex.Match(user.Password).Success ||
                !usernameRegex.Match(user.Username).Success)
            {
                throw new Exception("Incorrect input!");
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

            string tokenString = CreateJwt(session.User.Role.Name, session.User.ID.ToString());

            CreateSession(session.UserID, tokenString);
            unitOfWork.Sessions.Remove(session);
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

        private void CreateSession(int UserID, string token)
        {
            var session = new Session
            {
                UserID = UserID,
                Jwt = token
            };

            unitOfWork.Sessions.Add(session);
        }

        private string CreateJwt(string role, string ID)
        {
            var claims = new List<Claim>
            {
                new Claim("role", role),
                new Claim("ID", ID)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
