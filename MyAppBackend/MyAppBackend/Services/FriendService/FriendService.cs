using MyAppBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly DataContext context;

        public FriendService(DataContext context)
        {
            this.context = context;
        }

        public void SendFriendRequest() 
        {
            throw new NotImplementedException();
        }
        public void RemoveFriend()
        {
            throw new NotImplementedException();
        }
        public void AcceptFriendRequest()
        {
            throw new NotImplementedException();
        }
        public void DeclineFriendRequest()
        {
            throw new NotImplementedException();
        }
    }
}
