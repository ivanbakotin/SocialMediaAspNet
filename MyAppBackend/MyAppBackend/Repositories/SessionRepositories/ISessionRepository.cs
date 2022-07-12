using MyAppBackend.Models;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.SessionRepositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<Session> FindSession(string token);
    }
}
