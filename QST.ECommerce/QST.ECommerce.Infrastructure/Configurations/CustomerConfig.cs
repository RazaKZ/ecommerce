using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Infrastructure.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // 1. Table ka naam
            builder.ToTable("Customer");
            // 2. Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            // 3. Properties Validations
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(200);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(50);
            builder.Property(x => x.Address).HasColumnName("Address").HasMaxLength(500);
            builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        }
    }
}
