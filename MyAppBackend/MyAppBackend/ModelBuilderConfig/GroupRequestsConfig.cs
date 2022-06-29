using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class GroupRequestsConfig : IEntityTypeConfiguration<GroupRequest>
    {
        public void Configure(EntityTypeBuilder<GroupRequest> modelBuilder)
        {
            modelBuilder
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
