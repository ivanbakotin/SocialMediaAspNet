using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.FriendRepositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<Friend>> GetAllFriends(int id)
        {
            return (IEnumerable<Friend>)await context.Users.Where(x => x.ID == id)
                                      .Select(x => new
                                      {
                                          Friends1 = x.Friends1.Where(x => x.UserID1 != id).Select(p => new { p.User1.Username, p.User1.ID }),
                                          Friends11 = x.Friends1.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                          Friends2 = x.Friends2.Where(x => x.UserID1 != id).Select(p =>  new { p.User1.Username, p.User1.ID }),
                                          Friends22 = x.Friends2.Where(x => x.UserID2 != id).Select(p => new { p.User2.Username, p.User2.ID }),
                                      }).ToListAsync();
        }
    }
}
