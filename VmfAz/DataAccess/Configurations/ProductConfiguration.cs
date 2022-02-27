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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CostPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.BrandId).IsRequired();

        }
    }
}
