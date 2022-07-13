using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.FriendService
{
    public interface IFriendService
    {
        Task<IEnumerable<UserViewModel>> GetAllRequestsPending(int UserID);
        Task<IEnumerable<UserViewModel>> GetAllRequestsSent(int UserID);
        Task<IEnumerable<Friend>> GetAllFriends(int id);
        void SendFriendRequest(int UserID, int id);
        Task RemoveFriend(int UserID, int id);
        Task AcceptFriendRequest(int UserID, int id);
        Task RemoveFriendRequest(int UserID, int id);
    }
}
