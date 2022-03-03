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
    public class ProductEntryConfiguration : IEntityTypeConfiguration<ProductEntry>
    {
        public void Configure(EntityTypeBuilder<ProductEntry> builder)
        {
            builder.Property(x => x.ProductId).IsRequired();
            builder.HasOne(x => x.ProductBeltColor).WithMany(x => x.ProductEntriesForBelt).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProductDialColor).WithMany(x => x.ProductEntriesForDial).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
