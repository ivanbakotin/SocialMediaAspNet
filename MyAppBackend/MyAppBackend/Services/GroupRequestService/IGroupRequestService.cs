using MyAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupRequestService
{
    public interface IGroupRequestService
    {
        void SendGroupRequest(int id, int UserID);
        Task DeclineGroupRequest(int id, int UserID);
        void InviteToGroup(int GroupID, int UserID, int MemberID);
        Task AcceptInvitation(int UserID, int GroupID);
        Task AcceptRequest(int UserID, int GroupID);
        Task<IEnumerable<GroupRequest>> GetGroupRequestsSent(int GroupID);
        Task<IEnumerable<GroupRequest>> GetGroupRequestsPending(int GroupID);
        Task<IEnumerable<GroupRequest>> GetUserGroupRequestsSent(int UserID);
        Task<IEnumerable<GroupRequest>> GetUserGroupRequestsPending(int UserID);
    }
}
