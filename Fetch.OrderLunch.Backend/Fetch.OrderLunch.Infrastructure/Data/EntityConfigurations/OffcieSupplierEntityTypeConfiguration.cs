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
    public class OffcieSupplierEntityTypeConfiguration : IEntityTypeConfiguration<OfficeSupplier>
    {
        public void Configure(EntityTypeBuilder<OfficeSupplier> builder)
        {
            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.CreationTime);
            builder.Ignore(x => x.IsActive);
            builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.CreatorUserId);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(p => new { p.SupplierId, p.OfficeId });

            builder.HasOne<Office>()
                 .WithMany()    
                 .HasForeignKey(x=>x.OfficeId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
