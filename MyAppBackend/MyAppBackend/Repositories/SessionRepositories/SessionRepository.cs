using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.SessionRepositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Session> FindSession(string token)
        {
            return await context.Sessions.Include(x => x.User.Role).Where(x => x.Jwt == token).FirstOrDefaultAsync();
        }
    }
}
