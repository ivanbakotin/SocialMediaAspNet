using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.GroupRequestRepositories
{
    public class GroupRequestRepository : Repository<GroupRequest>, IGroupRequestRepository
    {
        public GroupRequestRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
