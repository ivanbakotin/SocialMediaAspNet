
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;

namespace MyAppBackend.Services.CommentService
{
    public interface ICommentService
    {
        List<CommentViewModel> GetComments(int UserID, int PostID);
        CommentViewModel CreateComment(Comment comment, int UserID);
        bool UpdateComment(Comment comment, int UserID, int CommnetID);
        bool DeleteComment(int UserID, int CommnetID);
        void VoteComment(int UserID, int CommnetID, bool vote);
    }
}
