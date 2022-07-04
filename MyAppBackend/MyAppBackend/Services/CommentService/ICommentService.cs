
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.CommentService
{
    public interface ICommentService
    {
        Task<List<CommentViewModel>> GetComments(int UserID, int PostID);
        Task<CommentViewModel> CreateComment(Comment comment, int UserID);
        Task UpdateComment(Comment comment, int UserID, int CommnetID);
        Task DeleteComment(int UserID, int CommnetID);
        Task VoteComment(int UserID, int CommnetID, bool vote);
    }
}
