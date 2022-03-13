using Core.Entities.Concrete;
using DataAccess.Configurations;
using DataAccess.Configurations.UserConfigurations;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class VmfAzContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SEQB6S7\SQLEXPRESS;Database=VmfAzProject;Trusted_Connection=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        ////ProductDetails
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductBeltType> ProductBeltTypes { get; set; }
        public DbSet<ProductCaseMaterial> ProductCaseMaterials { get; set; }
        public DbSet<ProductCaseShape> ProductCaseShapes { get; set; }
        public DbSet<ProductCaseSize> ProductCaseSizes { get; set; }
        public DbSet<ProductGlassType> ProductGlassTypes { get; set; }
        public DbSet<ProductMechanism> ProductMechanisms { get; set; }
        public DbSet<ProductStyle> ProductStyles { get; set; }
        public DbSet<ProductWaterResistance> ProductWaterResistances { get; set; }
        public DbSet<ProductFunctionality> ProductFunctionalities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());

            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemConfiguration());

            modelBuilder.ApplyConfiguration(new SliderConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
