using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class VotedPostConfig : IEntityTypeConfiguration<VotedPost>
    {
        public void Configure(EntityTypeBuilder<VotedPost> modelBuilder)
        {
            modelBuilder
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(c => c.Post)
                .WithMany(e => e.Votes);
        }
    }
}
