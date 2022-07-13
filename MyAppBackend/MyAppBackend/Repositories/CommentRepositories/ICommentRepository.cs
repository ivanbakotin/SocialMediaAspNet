using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.CommentRepositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<CommentViewModel>> GetComments(int UserID, int PostID);
    }
}
