using list.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace list.Infrastructure.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(10);
    }
}