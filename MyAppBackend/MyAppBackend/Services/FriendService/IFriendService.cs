namespace MyAppBackend.Services.FriendService
{
    public interface IFriendService
    {
        public void GetAllRequests();
        public void GetAllFriends(int id);
        public void SendFriendRequest(int UserID, int id);
        public void RemoveFriend(int UserID, int id);
        public void AcceptFriendRequest(int UserID, int id);
        public void RemoveFriendRequest(int UserID, int id);
    }
}
