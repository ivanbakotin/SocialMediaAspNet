using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> modelBuilder)
        {
            modelBuilder
                .HasMany(c => c.Votes)
                .WithOne(e => e.Post);

            modelBuilder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            modelBuilder.Property(x => x.Body).HasMaxLength(1000).IsRequired();
        }
    }
}
