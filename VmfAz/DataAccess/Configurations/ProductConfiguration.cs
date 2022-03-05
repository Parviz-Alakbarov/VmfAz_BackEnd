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
            builder.Property(x => x.GenderId).IsRequired();
            builder.Property(x => x.ProductFunctionalityId).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.ToolCount).IsRequired(false);
            builder.Property(x => x.WarrantyLimit).HasColumnType("decimal(3,1)");
            builder.Property(x => x.ProductStyleId).IsRequired(false);
            builder.Property(x => x.ProductWaterResistanceId).IsRequired(false);
            builder.Property(x => x.CountryId).IsRequired(false);
            builder.Property(x => x.ProductMechanismId).IsRequired(false);
            builder.Property(x => x.ProductGlassTypeId).IsRequired(false);
            builder.Property(x => x.ProductCaseMaterialId).IsRequired(false);
            builder.Property(x => x.ProductCaseShapeId).IsRequired(false);

            builder.HasOne(x=>x.ProductBeltColor).WithMany(x=>x.ProductsBelt).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ProductDialColor).WithMany(x=>x.ProductsDial).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ProductCaseSize).WithMany(x=>x.Products).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ProductBeltType).WithMany(x=>x.Products).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
