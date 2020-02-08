using Fetch.OrderLunch.Core.Entities.BasketAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.BuyerId)
                .IsRequired();

           
        }
    }
}
