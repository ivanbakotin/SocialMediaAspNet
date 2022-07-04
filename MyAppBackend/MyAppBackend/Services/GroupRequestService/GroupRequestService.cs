using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupRequestService
{
    public class GroupRequestService : IGroupRequestService
    {
        private readonly DataContext context;

        public GroupRequestService(DataContext context)
        {
            this.context = context;
        }

        public async Task SendGroupRequest(int id, int UserID)
        {
            var newGroupRequest = new GroupRequest
            {
                UserID = UserID,
                GroupID = id,
            };

            await context.GroupRequests.AddAsync(newGroupRequest);
            await context.SaveChangesAsync();
        }

        public async Task DeclineGroupRequest(int GroupID, int UserID)
        {
            var newGroupRequest = await context.GroupRequests.Where(x => x.UserID == UserID && x.GroupID == GroupID).FirstOrDefaultAsync();
            context.GroupRequests.Remove(newGroupRequest);
            await context.SaveChangesAsync();
        }

        public async Task InviteToGroup(int id, int UserID, int MemberID)
        {
            var newGroupRequest = new GroupRequest
            {
                MemberID = MemberID,
                UserID = UserID,
                GroupID = id,
            };

           await context.GroupRequests.AddAsync(newGroupRequest);
           await context.SaveChangesAsync();
        }

        public async Task AcceptToGroup(int id, int UserID, int GroupID)
        {
            var newGroupRequest = await context.GroupRequests.Where(x => x.UserID == id && x.GroupID == GroupID).FirstOrDefaultAsync();
            context.GroupRequests.Remove(newGroupRequest);
            var newMember = new GroupMember
            {
                GroupID = GroupID,
                UserID = UserID,
                RoleID = 2
            };
            await context.GroupMembers.AddAsync(newMember);
            await context.SaveChangesAsync();
        }

        public async Task GetGroupRequestsSent(int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task GetGroupRequestsPending(int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task GetUserGroupRequestsSent(int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task GetUserGroupRequestsPending(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
