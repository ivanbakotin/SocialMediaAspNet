using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<CommentViewModel>> GetComments(int UserID, int PostID)
        {
            var result = await mapper.ProjectTo<CommentViewModel>(
                                from comment in context.Comments
                                where comment.PostID == PostID
                                select comment, new { CurrentUserID = UserID })
                                .ToListAsync();

            return result;
        }

        public async Task<CommentViewModel> CreateComment(Comment comment, int UserID)
        {
            comment.UserID = UserID;
            comment.PostID = comment.PostID;
            comment.CommentID = comment?.CommentID;
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            CommentViewModel createdPost = mapper.Map<CommentViewModel>(comment);

            return createdPost;
        }

        public async Task UpdateComment(Comment comment, int UserID, int CommentID)
        {
            var commentToUpdate = await context.Comments.Where(p => p.ID == CommentID).FirstOrDefaultAsync();

            if (commentToUpdate != null)
            {
                commentToUpdate.Body = comment.Body;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteComment(int UserID, int CommentID)
        {
            var commentToDelete = await context.Comments.Where(p => p.ID == CommentID).FirstOrDefaultAsync();

            if (commentToDelete != null)
            {
                context.Comments.Remove(commentToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task VoteComment(int UserID, int CommentID, bool vote)
        {
            var votedComment = await context.VotedComments.Where(vp => vp.CommentID == CommentID && vp.UserID == UserID).FirstOrDefaultAsync();

            if (votedComment == null)
            {
                VotedComment newVotedComment = new()
                {
                    UserID = UserID,
                    CommentID = CommentID,
                    Liked = vote
                };

                await context.VotedComments.AddAsync(newVotedComment);
            }
            else if (votedComment.Liked != vote)
            {
                votedComment.Liked = vote;
            }
            else
            {
                context.VotedComments.Remove(votedComment);
            }

            await context.SaveChangesAsync();
        }
    }
}
