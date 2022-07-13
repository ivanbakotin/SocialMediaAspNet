using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.FriendRequestRepositories
{
    public interface IFriendRequestRepository : IRepository<FriendRequest>
    {
        Task<IEnumerable<UserViewModel>> GetAllRequestsPending(int UserID);
        Task<IEnumerable<UserViewModel>> GetAllRequestsSent(int UserID);
    }
}
