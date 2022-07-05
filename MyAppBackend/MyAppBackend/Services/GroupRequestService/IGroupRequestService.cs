﻿using MyAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupRequestService
{
    public interface IGroupRequestService
    {
        Task SendGroupRequest(int id, int UserID);
        Task DeclineGroupRequest(int id, int UserID);
        Task InviteToGroup(int GroupID, int UserID, int MemberID);
        Task AcceptInvitation(int UserID, int GroupID);
        Task AcceptRequest(int UserID, int GroupID);
        Task<List<GroupRequest>> GetGroupRequestsSent(int GroupID);
        Task<List<GroupRequest>> GetGroupRequestsPending(int GroupID);
        Task<List<GroupRequest>> GetUserGroupRequestsSent(int UserID);
        Task<List<GroupRequest>> GetUserGroupRequestsPending(int UserID);
    }
}
