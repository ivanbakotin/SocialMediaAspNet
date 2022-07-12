using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> modelBuilder)
        {
            modelBuilder
                .HasOne(e => e.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
