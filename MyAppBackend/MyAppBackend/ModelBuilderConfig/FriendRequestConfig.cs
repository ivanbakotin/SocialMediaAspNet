using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class FriendRequestsConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> modelBuilder)
        {
            modelBuilder
                   .HasOne(x => x.Follower)
                   .WithMany(x => x.FriendRequestsMe)
                   .HasForeignKey(x => x.FollowerID)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                    .HasOne(x => x.User)
                    .WithMany(x => x.FriendRequestsThem)
                    .HasForeignKey(x => x.UserID);

            //modelBuilder.HasIndex(p => new { p.UserID, p.FollowerID }).IsUnique();
        }
    }
}
