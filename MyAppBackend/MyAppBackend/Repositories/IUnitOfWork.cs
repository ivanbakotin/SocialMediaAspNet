using MyAppBackend.Repositories.GroupRepositories;
using MyAppBackend.Repositories.PostRepositories;
using MyAppBackend.Repositories.TagRepositories;
using MyAppBackend.Repositories.UserRepositories;
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
        int Save();
    }
}
