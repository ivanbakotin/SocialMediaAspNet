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

namespace MyAppBackend.Services.Auth
{
    public class AuthService : IAuthService
    {
        public string Login(User user, DataContext context)
        {
            var userObject = context.Users
                               .Join(context.Roles,
                                       user => user.roleID,
                                       role => role.ID,
                                       (user, role) => new
                                       {
                                           ID = user.ID,
                                           email = user.email,
                                           password = user.password,
                                           role = role.role,
                                       })
                               .Where(u => u.email == user.email)
                               .FirstOrDefault();

            if (userObject == null)
            {
                return null;
            }

            string hashedPassword = CustomHash.HashString(user.password);

            if (hashedPassword != userObject.password)
            {
                return null;
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("role", userObject.role));
            claims.Add(new Claim("ID", userObject.ID.ToString()));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeysecretkeysecretkeysecretkey"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }

        public bool Register(User user, DataContext context)
        {
            //check password, email regex

            bool emailExists = context.Users.Any(u => u.email == user.email);

            if (emailExists)
            {
                return false;
            }

            string hashedPassword = CustomHash.HashString(user.password);

            User newUser = new User
            {
                email = user.email,
                password = hashedPassword,
                roleID = 2
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            Profile newProfile = new Profile
            {
                userID = newUser.ID
            };

            context.Profiles.Add(newProfile);
            context.SaveChanges();

            return true;
        }
    }
}
