using MyAppBackend.Repositories.CommentRepositories;
using MyAppBackend.Repositories.FriendRepositories;
using MyAppBackend.Repositories.FriendRequestRepositories;
using MyAppBackend.Repositories.GroupMemberRepositories;
using MyAppBackend.Repositories.GroupRepositories;
using MyAppBackend.Repositories.GroupRequestRepositories;
using MyAppBackend.Repositories.PostRepositories;
using MyAppBackend.Repositories.ProfileRepositories;
using MyAppBackend.Repositories.SessionRepositories;
using MyAppBackend.Repositories.TagRepositories;
using MyAppBackend.Repositories.UserRepositories;
using MyAppBackend.Repositories.VotedCommentRepositories;
using MyAppBackend.Repositories.VotedPostRepositories;
using System;

namespace MyAppBackend.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        IVotedPostRepository VotedPosts { get;  }
        ITagRepository Tags { get; }
        IGroupRepository Groups { get; }
        IUserRepository Users { get; }
        IProfileRepository Profiles { get; }
        IVotedCommentRepository VotedComments { get; }
        ICommentRepository Comments { get; }
        IGroupMemberRepository GroupMembers { get; }
        IGroupRequestRepository GroupRequests { get; }
        IFriendRepository Friends { get; }
        IFriendRequestRepository FriendRequests { get; }
        ISessionRepository Sessions { get; }
        int Save();
    }
}
