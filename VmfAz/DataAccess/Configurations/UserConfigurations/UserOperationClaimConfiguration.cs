using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.UserConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.Property(x => x.OperationClaimId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserOperationClaims);
            builder.HasOne(x => x.OperationClaim).WithMany(x => x.UserOperationClaims);
        }
    }
}
