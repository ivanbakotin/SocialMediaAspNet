using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.VotedRepositories
{
    public class VotedPostRepository : Repository<VotedPost>, IVotedPostRepository
    {
        public VotedPostRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
