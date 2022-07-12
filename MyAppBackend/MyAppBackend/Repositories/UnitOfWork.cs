using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Repositories.PostRepositories;
using MyAppBackend.Repositories.VotedRepositories;

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
            VotedPosts = new VotedPostRepository(this.context, this.mapper);
            Tags = new TagRepository(this.context, this.mapper);
        }

        public IPostRepository Posts { get; private set; }
        public IVotedPostRepository VotedPosts { get; private set; }
        public ITagRepository Tags { get; private set; }

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
