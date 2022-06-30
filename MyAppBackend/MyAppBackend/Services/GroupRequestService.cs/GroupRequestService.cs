using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Linq;

namespace MyAppBackend.Services.GroupRequestService
{
    public class GroupRequestService : IGroupRequestService
    {
        private readonly DataContext context;

        public GroupRequestService(DataContext context)
        {
            this.context = context;
        }

        public void SendGroupRequest(int id, int UserID)
        {
            var newGroupRequest = new GroupRequest
            {
                UserID = UserID,
                GroupID = id,
            };

            context.GroupRequests.Add(newGroupRequest);
            context.SaveChanges();
        }

        public void DeclineGroupRequest(int GroupID, int UserID)
        {
            var newGroupRequest = context.GroupRequests.Where(x => x.UserID == UserID && x.GroupID == GroupID).FirstOrDefault();
            context.GroupRequests.Remove(newGroupRequest);
            context.SaveChanges();
        }

        public void InviteToGroup(int id, int UserID, int MemberID)
        {
            var newGroupRequest = new GroupRequest
            {
                MemberID = MemberID,
                UserID = UserID,
                GroupID = id,
            };

            context.GroupRequests.Add(newGroupRequest);
            context.SaveChanges();
        }

        public void AcceptToGroup(int id, int UserID, int GroupID)
        {
            throw new NotImplementedException();
        }

        public void GetGroupRequestsSent(int UserID)
        {
            throw new NotImplementedException();
        }

        public void GetGroupRequestsPending(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
