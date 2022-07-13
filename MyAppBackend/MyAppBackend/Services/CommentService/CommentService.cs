using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommentViewModel>> GetComments(int UserID, int PostID)
        {
            return await unitOfWork.Comments.GetComments(UserID, PostID);
        }

        public CommentViewModel CreateComment(Comment comment, int UserID)
        {
            comment.UserID = UserID;
            comment.PostID = comment.PostID;
            comment.CommentID = comment?.CommentID;
            unitOfWork.Comments.Add(comment);
            unitOfWork.Save();
            return mapper.Map<CommentViewModel>(comment);
        }

        public async Task UpdateComment(Comment comment, int CommentID)
        {
            var commentToUpdate = await unitOfWork.Comments.Find(p => p.ID == CommentID);

            if (commentToUpdate != null)
            {
                commentToUpdate.Body = comment.Body;
                unitOfWork.Save();
            }
        }

        public async Task DeleteComment(int CommentID)
        {
            var commentToDelete = await unitOfWork.Comments.Find(p => p.ID == CommentID);

            if (commentToDelete != null)
            {
                unitOfWork.Comments.Remove(commentToDelete);
                unitOfWork.Save();
            }
        }

        public async Task VoteComment(int UserID, int CommentID, bool vote)
        {
            var votedComment = await unitOfWork.VotedComments.Find(vp => vp.CommentID == CommentID && vp.UserID == UserID);

            if (votedComment == null)
            {
                VotedComment newVotedComment = new()
                {
                    UserID = UserID,
                    CommentID = CommentID,
                    Liked = vote
                };

                unitOfWork.VotedComments.Add(newVotedComment);
            }
            else if (votedComment.Liked != vote)
            {
                votedComment.Liked = vote;
            }
            else
            {
                unitOfWork.VotedComments.Remove(votedComment);
            }

            unitOfWork.Save();
        }
    }
}
