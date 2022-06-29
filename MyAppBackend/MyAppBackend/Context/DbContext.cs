using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppBackend.ModelBuilderConfig;
using MyAppBackend.Models;

namespace MyAppBackend.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ResetCode> ResetCodes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<VotedPost> VotedPosts { get; set; }
        public DbSet<VotedComment> VotedComments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupRequest> GroupRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           new FriendRequestsConfig().Configure(modelBuilder.Entity<FriendRequest>());
           new CommentConfig().Configure(modelBuilder.Entity<Comment>());
           new FriendConfig().Configure(modelBuilder.Entity<Friend>());
           new PostConfig().Configure(modelBuilder.Entity<Post>());
           new VotedCommentConfig().Configure(modelBuilder.Entity<VotedComment>());
           new VotedPostConfig().Configure(modelBuilder.Entity<VotedPost>());
           new GroupMemberConfig().Configure(modelBuilder.Entity<GroupMember>());
           new GroupRequestsConfig().Configure(modelBuilder.Entity<GroupRequest>());
        }
    }
}