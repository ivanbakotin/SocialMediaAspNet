using Microsoft.IdentityModel.Tokens;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MyAppBackend.Utilities;
using MyAppBackend.ApiModels;

namespace MyAppBackend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext context;

        public AuthService(DataContext context)
        {
            this.context = context;
        }

        public string Login(LoginUser user)
        {
            var userObject = context.Users
                               .Join(context.Roles,
                                       user => user.RoleID,
                                       role => role.ID,
                                       (user, role) => new
                                       {
                                           ID = user.ID,
                                           email = user.Email,
                                           password = user.Password,
                                           role = role.RoleName,
                                       })
                               .Where(u => u.email == user.Email)
                               .FirstOrDefault();

            if (userObject == null)
            {
                return null;
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            if (hashedPassword != userObject.password)
            {
                return null;
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("role", userObject.role));
            claims.Add(new Claim("ID", userObject.ID.ToString()));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            if (user.RememberMe)
            {
                var session = new Session
                {
                    UserID = userObject.ID,
                    Jwt = tokenString
                };

                context.Sessions.Add(session);
                context.SaveChanges();
            }

            return tokenString;
        }

        public bool Register(User user)
        {
            //check password, email regex

            bool userExists = context.Users.Any(u => u.Email == user.Email || u.Username == user.Username);

            if (userExists)
            {
                return false;
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            User newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = hashedPassword,
                RoleID = 2
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            Profile newProfile = new Profile { UserID = newUser.ID };

            context.Profiles.Add(newProfile);
            context.SaveChanges();

            return true;
        }

        public string IsLoggedIn(string token)
        {
            var session = context.Sessions.Where(x => x.Jwt == token).FirstOrDefault();

            if (session == null)
            {
                return null;
            }

            var claims = new List<Claim>();
            //claims.Add(new Claim("role", session.User.Role.RoleName));
            claims.Add(new Claim("ID", 1.ToString()));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            context.Sessions.RemoveRange(session);

            var newSession = new Session
            {
                UserID = 1,
                Jwt = tokenString
            };

            context.Sessions.Add(newSession);
            context.SaveChanges();

            return tokenString;
        }

        public void Logout(int UserID)
        {
            var sessionToDelete = context.Sessions.Where(x => x.UserID == UserID).ToList();

            if (sessionToDelete != null)
            {
                context.Sessions.RemoveRange(sessionToDelete);
                context.SaveChanges();
            }
        }
    }
}
