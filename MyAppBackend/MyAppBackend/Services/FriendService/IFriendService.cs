using System.Threading.Tasks;

namespace MyAppBackend.Services.FriendService
{
    public interface IFriendService
    {
        Task<dynamic> GetAllRequestsPending(int UserID);
        Task<dynamic> GetAllRequestsSent(int UserID);
        Task<dynamic> GetAllFriends(int id);
        Task SendFriendRequest(int UserID, int id);
        Task RemoveFriend(int UserID, int id);
        Task AcceptFriendRequest(int UserID, int id);
        Task RemoveFriendRequest(int UserID, int id);
    }
}
