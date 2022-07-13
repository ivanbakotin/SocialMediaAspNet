using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.FriendRequestRepositories
{
    public class FriendRequestRepository : Repository<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<UserViewModel>> GetAllRequestsPending(int UserID)
        {
            return await context.Users.Where(u => u.ID == UserID)
                                      .SelectMany(x => x.FriendRequestsThem
                                      .Select(x => new UserViewModel { Username = x.Follower.Username, ID = x.Follower.ID }
                                      )).ToListAsync();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllRequestsSent(int UserID)
        {
            return await context.Users.Where(u => u.ID == UserID)
                                     .SelectMany(x => x.FriendRequestsMe
                                     .Select(x => new UserViewModel { Username = x.Follower.Username, ID = x.Follower.ID }
                                     )).ToListAsync();
        }
    }
}
