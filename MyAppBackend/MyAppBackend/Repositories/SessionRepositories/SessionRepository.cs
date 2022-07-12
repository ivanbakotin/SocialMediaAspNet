using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.SessionRepositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
