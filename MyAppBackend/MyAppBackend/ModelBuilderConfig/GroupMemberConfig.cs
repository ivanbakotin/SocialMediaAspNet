using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppBackend.Models;

namespace MyAppBackend.ModelBuilderConfig
{
    public class GroupMemberConfig: IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> modelBuilder)
        {
            modelBuilder
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


