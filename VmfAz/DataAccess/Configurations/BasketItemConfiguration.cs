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
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Product).WithMany(x=>x.BasketItems).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
