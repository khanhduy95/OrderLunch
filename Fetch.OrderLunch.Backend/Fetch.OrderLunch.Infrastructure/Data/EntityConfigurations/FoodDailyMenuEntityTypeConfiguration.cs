using Fetch.OrderLunch.Core.Entities;
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class FoodDailyMenuEntityTypeConfiguration : IEntityTypeConfiguration<FoodDailyMenu>
    {
        public void Configure(EntityTypeBuilder<FoodDailyMenu> builder)
        {
           
            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.CreationTime);
            builder.Ignore(x => x.IsActive);
           // builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.CreatorUserId);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(x => new { x.FoodId, x.DailyMenuId });
           // builder.Property(x => new { x.FoodId, x.DailyMenuId }).UseSqlServerIdentityColumn().ValueGeneratedOnAddOrUpdate();

            //////////
            builder.HasOne(x => x.Food)
                .WithMany(x => x.FoodDailyMenus)
                .HasForeignKey(x => x.FoodId);

            builder.HasOne(x => x.DailyMenu)
                .WithMany(x => x.FoodDailyMenus)
                .HasForeignKey(x => x.DailyMenuId);

        }
    }
}
