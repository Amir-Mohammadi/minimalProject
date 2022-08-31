using minimalProject.Core.Domains.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace minimalProject.Core
{
    public class IpDetectMap : IEntityTypeConfiguration<IpDetect>
    {
        public void Configure(EntityTypeBuilder<IpDetect> builder)
        {
            builder.ToTable("IpDetects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ip);
            builder.Property(x => x.type);
            builder.Property(x => x.continent_code);
            builder.Property(x => x.continent_name);
            builder.Property(x => x.country_code);
            builder.Property(x => x.country_name);
            builder.Property(x => x.region_code);
            builder.Property(x => x.region_name);
            builder.Property(x => x.city);
            builder.Property(x => x.zip);
            builder.Property(x => x.latitude);
            builder.Property(x => x.longitude);
            builder.Property(x => x.country_flag);
            builder.Property(x => x.country_flag_emoji);
            builder.Property(x => x.country_flag_emoji_unicode);
            builder.Property(x => x.calling_code);
            builder.Property(x => x.is_eu);











            


            
        }
    }
}