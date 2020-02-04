
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Ignore(x => x.DomainEvents);

           
            builder.Property<int>(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.Address)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.HotLine)
                   .HasMaxLength(200)
                   .IsRequired();  
                      
        }     
    }       
}
