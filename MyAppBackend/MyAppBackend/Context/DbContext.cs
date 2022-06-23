using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FIX restrictions
            modelBuilder.Entity<Comment>()
                .HasOne(e => e.CommentVirtual)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VotedComment>()
                .HasOne(e => e.Comment)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VotedPost>()
                .HasOne(e => e.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FriendRequest>()
                .HasOne(e => e.Follower)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                        .HasMany(c => c.Votes)
                        .WithOne(e => e.Post);

            modelBuilder.Entity<VotedPost>()
                        .HasOne(c => c.Post)
                        .WithMany(e => e.Votes);

            modelBuilder.Entity<FriendRequest>()
                        .HasIndex(p => new { p.UserID, p.FollowerID }).IsUnique();
        }
    }
}