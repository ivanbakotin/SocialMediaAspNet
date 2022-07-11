using Microsoft.EntityFrameworkCore;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext context;

        public AuthService(DataContext context)
        {
            this.context = context;
        }

        public async Task<AuthenticatedResponse> Login(LoginUser user)
        {
            var userObject = await context.Users.Include(u => u.Role).Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            if (userObject == null)
            {
                return null;
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            if (hashedPassword != userObject.Password)
            {
                return null;
            }

            string tokenString = CreateJwt.GetJwt(userObject.Role.Name, userObject.ID.ToString());

            if (user.RememberMe)
            {
                var session = new Session
                {
                    UserID = userObject.ID,
                    Jwt = tokenString
                };

                await context.Sessions.AddAsync(session);
                await context.SaveChangesAsync();
            }

            return new AuthenticatedResponse { Token = tokenString };
        }

        public async Task<bool> Register(User user)
        {
            //check password, email regex

            bool userExists = context.Users.Any(u => u.Email == user.Email || u.Username == user.Username);

            if (userExists)
            {
                return false;
            }

            string hashedPassword = CustomHash.HashString(user.Password);

            User newUser = new()
            {
                Username = user.Username,
                Email = user.Email,
                Password = hashedPassword,
                RoleID = 2
            };

            await context .Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            Profile newProfile = new() { UserID = newUser.ID };

            await context.Profiles.AddAsync(newProfile);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<string> IsLoggedIn(string token)
        {
            var session = await context.Sessions.Include(x => x.User.Role).Where(x => x.Jwt == token).FirstOrDefaultAsync();

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

            context.Sessions.RemoveRange(session);
            await context.Sessions.AddAsync(newSession);
            await context.SaveChangesAsync();

            return tokenString;
        }

        public async Task Logout(int UserID)
        {
            var sessionToDelete = await context.Sessions.Where(x => x.UserID == UserID).ToListAsync();

            if (sessionToDelete != null)
            {
                context.Sessions.RemoveRange(sessionToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
