using Fetch.OrderLunch.Core.Entities.BuyerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Data.EntityConfigurations
{
    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.CreationTime);
            builder.Ignore(x => x.CreatorUserId);
            builder.Ignore(x => x.IsActive);
            


            builder.Property(x => x.IdentityGuid)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex("IdentityGuid")
                .IsUnique(true);

            builder.Property(x => x.Name);

           
        }

       
    }
}
