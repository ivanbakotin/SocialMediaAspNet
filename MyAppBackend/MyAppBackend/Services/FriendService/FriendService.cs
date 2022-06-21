using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Linq;

namespace MyAppBackend.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly DataContext context;

        public FriendService(DataContext context)
        {
            this.context = context;
        }

        public void SendFriendRequest(int UserID, int id) 
        {
            var newFriendRequest = new FriendRequest
            {
                UserID = id,
                FollowerID = UserID
            };

            context.FriendRequests.Add(newFriendRequest);
        }

        public void RemoveFriend(int UserID, int id)
        {
            var toDeleteFriend = context.Friends
                                            .Where(f => ((f.UserID2 == UserID && f.UserID1 == id)
                                                      || (f.UserID1 == UserID && f.UserID2 == id)))
                                            .FirstOrDefault();

            if (toDeleteFriend != null)
            {
                context.Friends.Remove(toDeleteFriend);
                context.SaveChanges();
            }
        }

        public void AcceptFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = context.FriendRequests
                                            .Where(f => ((f.UserID == UserID && f.FollowerID == id)
                                                      || (f.FollowerID == UserID && f.UserID == id)))
                                            .FirstOrDefault();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
            }

            var newFriend = new Friend
            {
                UserID1 = id,
                UserID2 = UserID
            };

            context.Friends.Add(newFriend);
            context.SaveChanges();
        }

        public void RemoveFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = context.FriendRequests
                                            .Where(f => ((f.UserID == UserID && f.FollowerID == id)
                                                      || (f.FollowerID == UserID && f.UserID == id)))
                                            .FirstOrDefault();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
                context.SaveChanges();
            }
        }
    }
}
