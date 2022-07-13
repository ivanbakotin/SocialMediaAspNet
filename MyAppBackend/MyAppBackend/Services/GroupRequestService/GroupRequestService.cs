using MyAppBackend.Models;
using MyAppBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


/*
    Member
        remove invite
        accept request from user
 */

namespace MyAppBackend.Services.GroupRequestService
{
    public class GroupRequestService : IGroupRequestService
    {
        private readonly IUnitOfWork unitOfWork;

        public GroupRequestService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void SendGroupRequest(int id, int UserID)
        {
            GroupRequest newGroupRequest = new() { UserID = UserID, GroupID = id };
            unitOfWork.GroupRequests.Add(newGroupRequest);
            unitOfWork.Save();
        }
        public void InviteToGroup(int GroupID, int UserID, int MemberID)
        {
            GroupRequest newGroupRequest = new()
            {
                MemberID = MemberID,
                UserID = UserID,
                GroupID = GroupID,
            };
            unitOfWork.GroupRequests.Add(newGroupRequest);
            unitOfWork.Save();
        }

        public async Task DeclineGroupRequest(int GroupID, int UserID)
        {
            var newGroupRequest = await unitOfWork.GroupRequests.Find(x => x.UserID == UserID && x.GroupID == GroupID);
            unitOfWork.GroupRequests.Remove(newGroupRequest);
            unitOfWork.Save();
        }

        public async Task AcceptInvitation(int UserID, int GroupID)
        {
            var newGroupRequest = await unitOfWork.GroupRequests.Find(x => x.UserID == UserID && x.GroupID == GroupID);
            unitOfWork.GroupRequests.Remove(newGroupRequest);
            GroupMember newMember = new()
            {
                GroupID = newGroupRequest.GroupID,
                UserID = UserID,
                RoleID = 2
            };
            unitOfWork.GroupMembers.Add(newMember);
            unitOfWork.Save();
        }

        public async Task AcceptRequest(int UserID, int GroupID)
        {

        }

        public async Task<IEnumerable<GroupRequest>> GetGroupRequestsSent(int GroupID)
        {
            return await unitOfWork.GroupRequests.FindAll(x => x.GroupID == GroupID && x.MemberID != null);
        }

        public async Task<IEnumerable<GroupRequest>> GetGroupRequestsPending(int GroupID)
        {
            return await unitOfWork.GroupRequests.FindAll(x => x.GroupID == GroupID && x.MemberID == null);
        }

        public async Task<IEnumerable<GroupRequest>> GetUserGroupRequestsSent(int UserID)
        {
            return await unitOfWork.GroupRequests.FindAll(x => x.UserID == UserID && x.MemberID == null);
        }

        public async Task<IEnumerable<GroupRequest>> GetUserGroupRequestsPending(int UserID)
        {
            return await unitOfWork.GroupRequests.FindAll(x => x.UserID == UserID && x.MemberID != null);
        }
    }
}
