using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.GroupRepositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
