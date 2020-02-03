
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Ignore(x => x.DomainEvents);
            
            builder.HasOne<Supplier>()
                   .WithOne()
                   .IsRequired();
        
        }
    }
}
