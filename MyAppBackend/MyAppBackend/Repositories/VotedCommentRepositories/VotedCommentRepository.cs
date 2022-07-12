using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.VotedCommentRepositories
{
    public class VotedCommentRepository : Repository<VotedComment>, IVotedCommentRepository
    {
        public VotedCommentRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
