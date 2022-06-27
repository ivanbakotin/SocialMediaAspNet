namespace MyAppBackend.Services.FriendService
{
    public interface IFriendService
    {
        dynamic GetAllRequestsPending(int UserID);
        dynamic GetAllRequestsSent(int UserID);
        dynamic GetAllFriends(int id);
        void SendFriendRequest(int UserID, int id);
        void RemoveFriend(int UserID, int id);
        void AcceptFriendRequest(int UserID, int id);
        void RemoveFriendRequest(int UserID, int id);
    }
}
