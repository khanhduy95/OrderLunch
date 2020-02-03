
using Fetch.OrderLunch.Core.Entities.CompanyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Infrastructure.Data.EntityConfigurations
{
    public class OfficeEntityTypeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Ignore(x => x.DomainEvents);

            builder.Property<int>(x => x.Id)
                   .IsRequired();

            builder.Property<int>(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.Address)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.HotLine)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne<Company>()
                .WithMany()
                .HasForeignKey(x=>x.CompanyId)
                .IsRequired();
            
        }
    }
}
