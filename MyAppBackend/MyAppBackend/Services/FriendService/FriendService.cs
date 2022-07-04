using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<dynamic> GetAllRequestsPending(int UserID)
        {
            var result = await context.Users.Where(u => u.ID == UserID)
                                      .Select(x => new
                                      {
                                          Requests = x.FriendRequestsThem.Select(p => new { p.Follower.Username, p.Follower.ID })
                                      }).ToListAsync();

            return result;
        }

        public async Task<dynamic> GetAllRequestsSent(int UserID)
        {
            var result = await context.Users.Where(u => u.ID == UserID)
                                      .Select(x => new
                                      {
                                          Requests = x.FriendRequestsMe.Select(p => new { p.User.Username, p.User.ID })
                                      }).ToListAsync();
            return result;
        }

        public async Task<dynamic> GetAllFriends(int id)
        {
            var result = await context.Users.Where(f => f.ID == id)
                                      .Select(x => new
                                      {
                                          Friends1 = x.Friends1.Where(x => x.UserID1 != id).Select(p => new { p.User1.Username, p.User1.ID }),
                                          Friends11 = x.Friends1.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                          Friends2 = x.Friends2.Where(x => x.UserID1 != id).Select(p =>  new { p.User1.Username, p.User1.ID }),
                                          Friends22 = x.Friends2.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                      }).ToListAsync();
            return result;
        }

        public async Task SendFriendRequest(int UserID, int id) 
        {
            FriendRequest newFriendRequest = new()
            {
                UserID = id,
                FollowerID = UserID
            };

            await context.FriendRequests.AddAsync(newFriendRequest);
            await context.SaveChangesAsync();
        }

        public async Task RemoveFriend(int UserID, int id)
        {
            var toDeleteFriend = await context.Friends
                                            .Where(f => (f.UserID2 == UserID && f.UserID1 == id)
                                                     || (f.UserID1 == UserID && f.UserID2 == id))
                                            .FirstOrDefaultAsync();

            if (toDeleteFriend != null)
            {
                context.Friends.Remove(toDeleteFriend);
                await context.SaveChangesAsync();
            }
        }

        public async Task AcceptFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await context.FriendRequests
                                            .Where(f => ((f.UserID == UserID && f.FollowerID == id)
                                                      || (f.FollowerID == UserID && f.UserID == id)))
                                            .FirstOrDefaultAsync();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
            }

            var newFriend = new Friend
            {
                UserID1 = id,
                UserID2 = UserID
            };

            await context.Friends.AddAsync(newFriend);
            await context.SaveChangesAsync();
        }

        public async Task RemoveFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await context.FriendRequests
                                            .Where(f => ((f.UserID == UserID && f.FollowerID == id)
                                                      || (f.FollowerID == UserID && f.UserID == id)))
                                            .FirstOrDefaultAsync();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
                await context.SaveChangesAsync();
            }
        }
    }
}
