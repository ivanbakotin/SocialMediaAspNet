using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupRequestService.cs
{
    interface IGroupRequestService
    {
        dynamic SendGroupRequest(int id);
        dynamic DeclineGroupRequest(int id);
        dynamic RemoveGroupRequest(int id);
        dynamic InviteToGroup(int id);
        dynamic AcceptToGroup(int id);
        dynamic GetGroupRequestsSent(int id);
        dynamic GetGroupRequestsPending(int id);
    }
}
