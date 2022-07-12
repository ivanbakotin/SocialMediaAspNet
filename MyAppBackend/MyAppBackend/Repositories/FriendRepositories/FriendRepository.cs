using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.FriendRepositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
