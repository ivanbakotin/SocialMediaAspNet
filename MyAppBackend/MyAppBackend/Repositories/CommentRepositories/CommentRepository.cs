using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.CommentRepositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<CommentViewModel>> GetComments(int UserID, int PostID)
        {
            return await mapper.ProjectTo<CommentViewModel>(
                                from comment in context.Comments
                                where comment.PostID == PostID
                                select comment, new { CurrentUserID = UserID })
                                .ToListAsync();
        }
    }
}
