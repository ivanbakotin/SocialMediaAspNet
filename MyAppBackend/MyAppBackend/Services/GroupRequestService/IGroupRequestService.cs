using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupRequestService
{
    public interface IGroupRequestService
    {
        Task SendGroupRequest(int id, int UserID);
        Task DeclineGroupRequest(int id, int UserID);
        Task InviteToGroup(int id, int UserID, int MemberID);
        Task AcceptToGroup(int id, int UserID, int GroupID);
        Task GetGroupRequestsSent(int UserID);
        Task GetGroupRequestsPending(int UserID);
        Task GetUserGroupRequestsSent(int UserID);
        Task GetUserGroupRequestsPending(int UserID);
    }
}
