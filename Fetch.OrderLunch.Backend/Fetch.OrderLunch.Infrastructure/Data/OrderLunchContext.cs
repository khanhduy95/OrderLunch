
using Fetch.OrderLunch.Core.Entities;
using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Core.SeedWork;
using Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.Infrastructure.Data
{
    public class OrderLunchContext : DbContext,IUnitOfWork
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<DailyMenu> DailyMenu { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> basketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<FoodDailyMenu> FoodDailyMenu { get; set; }
        public DbSet<OfficeSupplier> OfficeSuppliers { get; set; }

        public OrderLunchContext(DbContextOptions<OrderLunchContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DailyMenuEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BasketEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MethodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodDailyMenuEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OffcieSupplierEntityTypeConfiguration());

            ConfigurationHasQueryFilter<Company>(modelBuilder);
            ConfigurationHasQueryFilter<Office>(modelBuilder);            
            ConfigurationHasQueryFilter<Supplier>(modelBuilder);
            ConfigurationHasQueryFilter<Food>(modelBuilder);            
            ConfigurationHasQueryFilter<Menu>(modelBuilder);
            ConfigurationHasQueryFilter<DailyMenu>(modelBuilder);
            ConfigurationHasQueryFilter<Order>(modelBuilder);           
            ConfigurationHasQueryFilter<FoodDailyMenu>(modelBuilder);        
            ConfigurationHasQueryFilter<OfficeSupplier>(modelBuilder);
                     
        }

        private void ConfigurationHasQueryFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(p => !p.IsDeleted);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

       
    }
}
