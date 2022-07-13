
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.CommentService
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetComments(int UserID, int PostID);
        CommentViewModel CreateComment(Comment comment, int UserID);
        Task UpdateComment(Comment comment, int CommnetID);
        Task DeleteComment(int CommnetID);
        Task VoteComment(int UserID, int CommnetID, bool vote);
    }
}
