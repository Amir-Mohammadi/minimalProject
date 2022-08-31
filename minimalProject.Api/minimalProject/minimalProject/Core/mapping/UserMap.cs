using minimalProject.Core.Domains.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace minimalProject.Core
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.Email);
            builder.Property(x => x.Ip);
            builder.Property(x => x.Location);
            builder.Property(x => x.BirthDate);
            builder.Property(x => x.Link);

        }
    }
}