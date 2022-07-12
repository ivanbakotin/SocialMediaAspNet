using AutoMapper;
using MyAppBackend.Data;
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
            Groups = new GroupRepository(this.context, this.mapper);
            Users = new UserRepository(this.context, this.mapper);
            VotedComments = new VotedCommentRepository(this.context, this.mapper);
            Profiles = new ProfileRepository(this.context, this.mapper);
            Comments = new CommentRepository(this.context, this.mapper);
            GroupMembers = new GroupMemberRepository(this.context, this.mapper);
            GroupRequests = new GroupRequestRepository(this.context, this.mapper);
            Friends = new FriendRepository(this.context, this.mapper);
            FriendRequests = new FriendRequestRepository(this.context, this.mapper);
            Sessions = new SessionRepository(this.context, this.mapper);
        }

        public IPostRepository Posts { get; private set; }
        public IVotedPostRepository VotedPosts { get; private set; }
        public ITagRepository Tags { get; private set; }
        public IGroupRepository Groups { get; private set; }
        public IUserRepository Users { get; private set; }
        public IProfileRepository Profiles { get; }
        public IVotedCommentRepository VotedComments { get; }
        public ICommentRepository Comments { get; }
        public IGroupMemberRepository GroupMembers { get; }
        public IGroupRequestRepository GroupRequests { get; }
        public IFriendRepository Friends { get; }
        public IFriendRequestRepository FriendRequests { get; }
        public ISessionRepository Sessions { get; }

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
