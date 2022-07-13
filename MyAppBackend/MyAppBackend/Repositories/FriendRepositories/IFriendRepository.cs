using MyAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.FriendRepositories
{
    public interface IFriendRepository : IRepository<Friend>
    {
        Task<IEnumerable<Friend>> GetAllFriends(int id);
    }
}
