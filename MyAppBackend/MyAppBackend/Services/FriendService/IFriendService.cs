using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.FriendService
{
    public interface IFriendService
    {
        public void SendFriendRequest();
        public void RemoveFriend();
        public void AcceptFriendRequest();
        public void DeclineFriendRequest();
    }
}
