using MyAppBackend.Repositories.PostRepositories;
using System;

namespace MyAppBackend.Repositories
{
    interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        int Save();
    }
}
