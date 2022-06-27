﻿using MyAppBackend.Data;
using MyAppBackend.Models;
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

        public dynamic GetAllRequestsPending(int UserID)
        {
            var result = context.Users.Where(f => f.FriendRequestsThem.Any(a => a.UserID == UserID));
            return result;
        }

        public dynamic GetAllRequestsSent(int UserID)
        {
            var result = context.Users.Where(f => f.FriendRequestsMe.Any(a => a.FollowerID == UserID));
            return result;
        }

        public dynamic GetAllFriends(int id)
        {
            var result = context.Users.Where(f => f.Friends1.Any(f => f.UserID1 == id || f.UserID2 == id)
                                               || f.Friends2.Any(f => f.UserID1 == id || f.UserID2 == id));
            return result;
        }

        public void SendFriendRequest(int UserID, int id) 
        {
            var newFriendRequest = new FriendRequest
            {
                UserID = id,
                FollowerID = UserID
            };

            context.FriendRequests.Add(newFriendRequest);
            context.SaveChanges();
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
