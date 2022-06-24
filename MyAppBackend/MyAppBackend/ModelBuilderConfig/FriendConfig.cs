using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.User1)
                .WithMany(x => x.Friends1)
                .HasForeignKey(x => x.UserID1)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder       
                .HasOne(x => x.User2)
                .WithMany(x => x.Friends2)
                .HasForeignKey(x => x.UserID2);
        }
    }
}
