namespace MyAppBackend.Services.GroupRequestService
{
    public interface IGroupRequestService
    {
        void SendGroupRequest(int id, int UserID);
        void DeclineGroupRequest(int id, int UserID);
        void InviteToGroup(int id, int UserID, int MemberID);
        void AcceptToGroup(int id, int UserID, int GroupID);
        void GetGroupRequestsSent(int UserID);
        void GetGroupRequestsPending(int UserID);
    }
}
