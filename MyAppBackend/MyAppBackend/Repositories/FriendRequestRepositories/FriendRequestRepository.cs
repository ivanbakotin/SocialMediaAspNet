using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.FriendRequestRepositories
{
    public class FriendRequestRepository : Repository<Friend>, IFriendRequestRepository
    {
        public FriendRequestRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
