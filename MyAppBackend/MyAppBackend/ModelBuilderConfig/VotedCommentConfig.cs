using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class VotedCommentConfig : IEntityTypeConfiguration<VotedComment>
    {
        public void Configure(EntityTypeBuilder<VotedComment> modelBuilder)
        {
            modelBuilder
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
