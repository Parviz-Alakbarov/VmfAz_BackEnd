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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(x => x.ImagePath).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.ProductId).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
