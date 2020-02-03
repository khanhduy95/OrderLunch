
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Ignore(x => x.DomainEvents);

            builder.Property<int>(x => x.Id)
                   .IsRequired();

           

            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();
          
        }
    }
}
