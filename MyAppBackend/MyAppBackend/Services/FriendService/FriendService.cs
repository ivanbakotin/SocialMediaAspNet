using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;

namespace MyAppBackend.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public FriendService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public dynamic GetAllRequestsPending(int UserID)
        {
            var result = context.Users.Where(u => u.ID == UserID)
                                      .Select(x => new
                                      {
                                          Requests = x.FriendRequestsThem.Select(p => new { p.Follower.Username, p.Follower.ID })
                                      });

            return result;
        }

        public dynamic GetAllRequestsSent(int UserID)
        {
            var result = context.Users.Where(u => u.ID == UserID)
                                      .Select(x => new
                                      {
                                          Requests = x.FriendRequestsMe.Select(p => new { p.User.Username, p.User.ID })
                                      });
            return result;
        }

        public dynamic GetAllFriends(int id)
        {
            var result = context.Users.Where(f => f.ID == id)
                                      .Select(x => new
                                      {
                                          Friends1 = x.Friends1.Where(x => x.UserID1 != id).Select(p => new { p.User1.Username, p.User1.ID }),
                                          Friends11 = x.Friends1.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                          Friends2 = x.Friends2.Where(x => x.UserID1 != id).Select(p =>  new { p.User1.Username, p.User1.ID }),
                                          Friends22 = x.Friends2.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                      });
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
                                            .Where(f => (f.UserID2 == UserID && f.UserID1 == id)
                                                     || (f.UserID1 == UserID && f.UserID2 == id))
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
