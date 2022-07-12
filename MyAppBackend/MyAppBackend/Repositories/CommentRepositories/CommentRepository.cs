using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.CommentRepositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
