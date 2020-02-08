using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Data.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            

            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.CreationTime);
            builder.Ignore(x => x.CreatorUserId);
            builder.Ignore(x => x.IsActive);

            builder
                .Property<DateTime>("_orderDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OrderDate")
                .IsRequired();

            builder.Property<string>("Description").IsRequired(false);
           
            builder.HasOne<Buyer>()
               .WithMany()
               .IsRequired(false);

            builder.HasOne(o => o.OrderStatus)
                .WithMany();
                
        }
    }
}
