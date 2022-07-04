using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Collections.Generic;
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
            GroupRequest newGroupRequest = new() { UserID = UserID, GroupID = id };
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
            GroupRequest newGroupRequest = new()
            {
                MemberID = MemberID,
                UserID = UserID,
                GroupID = id,
            };

            await context.GroupRequests.AddAsync(newGroupRequest);
            await context.SaveChangesAsync();
        }

        public async Task AcceptToGroup(int UserID, int GroupID)
        {
            var newGroupRequest = await context.GroupRequests.Where(x => x.UserID == UserID && x.GroupID == GroupID).FirstOrDefaultAsync();
            context.GroupRequests.Remove(newGroupRequest);
            GroupMember newMember = new()
            {
                GroupID = newGroupRequest.GroupID,
                UserID = UserID,
                RoleID = 2
            };
            await context.GroupMembers.AddAsync(newMember);
            await context.SaveChangesAsync();
        }

        public async Task<List<GroupRequest>> GetGroupRequestsSent(int GroupID)
        {
            var result = await context.GroupRequests.Where(x => x.GroupID == GroupID && x.MemberID != null).ToListAsync();
            return result;
        }

        public async Task<List<GroupRequest>> GetGroupRequestsPending(int GroupID)
        {
            var result = await context.GroupRequests.Where(x => x.GroupID == GroupID && x.MemberID == null).ToListAsync();
            return result;
        }

        public async Task<List<GroupRequest>> GetUserGroupRequestsSent(int UserID)
        {
            var result = await context.GroupRequests.Where(x => x.UserID == UserID && x.MemberID == null).ToListAsync();
            return result;
        }

        public async Task<List<GroupRequest>> GetUserGroupRequestsPending(int UserID)
        {
            var result = await context.GroupRequests.Where(x => x.UserID == UserID && x.MemberID != null).ToListAsync();
            return result;
        }
    }
}
