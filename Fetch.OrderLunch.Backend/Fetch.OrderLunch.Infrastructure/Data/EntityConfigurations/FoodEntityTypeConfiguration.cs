
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class FoodEntityTypeConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Ignore(x => x.DomainEvents);

            builder.Property<int>(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Price)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(x => x.Image)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(x => x.Description)
               .HasMaxLength(200)
               .IsRequired();

            builder.HasOne<Category>()
                .WithMany()               
                .IsRequired()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
