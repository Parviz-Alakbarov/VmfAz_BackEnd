using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(2000).IsRequired();
            builder.Property(x=>x.Image).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PosterImage).HasMaxLength(100);
            builder.Property(x=>x.CreateDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
