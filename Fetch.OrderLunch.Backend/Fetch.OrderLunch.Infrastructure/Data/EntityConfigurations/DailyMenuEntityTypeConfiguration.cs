
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
   public class DailyMenuEntityTypeConfiguration : IEntityTypeConfiguration<DailyMenu>
    {
        public void Configure(EntityTypeBuilder<DailyMenu> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.CreationTime)
                .HasColumnType("date");

            builder.Ignore(x => x.DomainEvents);

            builder.Property<int>(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
