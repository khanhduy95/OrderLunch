using Fetch.OrderLunch.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Data.EntityConfigurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.CreationTime);
            builder.Ignore(x => x.CreatorUserId);
            builder.Ignore(x => x.IsActive);

            builder.Property<int>("ProductId")
                .IsRequired();

            builder.Property<int>("OrderId")
                .IsRequired();

            builder
                .Property<string>("_productName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ProductName")
                .IsRequired();

            builder
                .Property<decimal>("_unitPrice")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("UnitPrice")
                .IsRequired();

            builder
                .Property<int>("_units")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Units")
                .IsRequired();

            builder
                .Property<string>("_pictureUrl")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PictureUrl")
                .IsRequired(false);
        }
    }
}
