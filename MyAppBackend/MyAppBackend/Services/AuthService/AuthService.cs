using Microsoft.EntityFrameworkCore;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Utilities;
using System.Linq;

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
            var userObject = context.Users.Include(u => u.Role).Where(u => u.Email == user.Email).FirstOrDefault();

            if (userObject == null)
            {
                return null;
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            if (hashedPassword != userObject.Password)
            {
                return null;
            }

            string tokenString = CreateJwt.GetJwt(userObject.Role.RoleName, userObject.ID.ToString());

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
            var session = context.Sessions.Include(x => x.User.Role).Where(x => x.Jwt == token).FirstOrDefault();

            if (session == null)
            {
                return null;
            }

            string tokenString = CreateJwt.GetJwt(session.User.Role.RoleName, session.User.ID.ToString());

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
