using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppBackend.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public CommentService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public List<CommentViewModel> GetComments(int UserID, int PostID)
        {
            var result = mapper.ProjectTo<CommentViewModel>(
                                from comment in context.Comments
                                where comment.PostID == PostID
                                select comment, new { CurrentUserID = UserID })
                                .ToList();

            return result;
        }

        public CommentViewModel CreateComment(Comment comment, int UserID)
        {
            comment.UserID = UserID;
            comment.PostID = comment.PostID;
            comment.CommentID = comment?.CommentID;
            context.Comments.Add(comment);
            context.SaveChanges();

            CommentViewModel createdPost = mapper.Map<CommentViewModel>(comment);

            return createdPost;
        }

        public bool UpdateComment(Comment comment, int UserID, int CommentID)
        {
            var commentToUpdate = context.Comments.Where(p => p.ID == CommentID).FirstOrDefault();

            if (commentToUpdate != null)
            {
                commentToUpdate.Body = comment.Body;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteComment(int UserID, int CommentID)
        {
            var commentToDelete = context.Comments.Where(p => p.ID == CommentID).FirstOrDefault();

            if (commentToDelete != null)
            {
                context.Comments.Remove(commentToDelete);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public void VoteComment(int UserID, int CommentID, bool vote)
        {
            var votedComment = context.VotedComments.Where(vp => vp.CommentID == CommentID && vp.UserID == UserID).FirstOrDefault();

            if (votedComment == null)
            {
                VotedComment newVotedComment = new()
                {
                    UserID = UserID,
                    CommentID = CommentID,
                    Liked = vote
                };

                context.VotedComments.Add(newVotedComment);
            }
            else if (votedComment.Liked != vote)
            {
                votedComment.Liked = vote;
            }
            else
            {
                context.VotedComments.Remove(votedComment);
            }

            context.SaveChanges();
        }
    }
}
