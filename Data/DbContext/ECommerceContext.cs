using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECommerce.Models;


namespace ECommerce.Data.DbContext
{
    public class ECommerceContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("ECommerce");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(25);
                entity.Property(c => c.Gender).IsRequired().HasMaxLength(5);

                    
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Make).IsRequired().HasMaxLength(25);
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Composition).HasMaxLength(50);
                entity.Property(p => p.ImageUrl).IsRequired().HasMaxLength(100);

                entity.HasOne(c => c.Category).WithMany(p => p.Products)
                    .HasForeignKey(c => c.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(pa => pa.Id);
                entity.Property(pa => pa.Price).IsRequired().HasPrecision(18, 2);
                entity.Property(pa => pa.Discount).HasDefaultValue(0);
                entity.Property(pa => pa.Size).HasDefaultValue("One Size available").HasMaxLength(25);
                entity.Property(pa => pa.Quantity).IsRequired();

                entity.HasOne(p => p.Product).WithMany(pa => pa.ProductAttributes)
                    .HasForeignKey(p => p.ProductId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(op => op.Quantity).IsRequired();
                
                entity.HasOne(o => o.Order).WithMany(op => op.OrderProducts)
                    .HasForeignKey(o => o.OrderId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Product).WithMany(op => op.OrderProducts)
                    .HasForeignKey(p => p.ProductId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
                entity.Property(u => u.Role).IsRequired().HasDefaultValue("User").HasMaxLength(10);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(20);
                entity.Property(u => u.Surname).IsRequired().HasMaxLength(20);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired();
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Date).IsRequired();
                entity.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); ;
                entity.Property(o => o.TotalQuantity).IsRequired();

                entity.HasOne(u => u.User).WithMany(o => o.Orders)
                    .HasForeignKey(u => u.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
