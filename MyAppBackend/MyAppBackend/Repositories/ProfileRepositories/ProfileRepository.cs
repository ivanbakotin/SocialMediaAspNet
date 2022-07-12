using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.ProfileRepositories
{
    public class ProfileRepository : Repository<Models.Profile>, IProfileRepository
    {
        public ProfileRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
