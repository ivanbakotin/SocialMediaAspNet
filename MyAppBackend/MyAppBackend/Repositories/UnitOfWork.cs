using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Repositories.PostRepositories;

namespace MyAppBackend.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            Posts = new PostRepository(this.context, this.mapper);
        }

        public IPostRepository Posts { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
