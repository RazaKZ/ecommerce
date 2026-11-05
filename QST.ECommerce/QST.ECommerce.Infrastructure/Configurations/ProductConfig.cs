using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.Configurations;

// Class to Map Product Entity with the Underlying Database Table (Product)
// Purpose: Mapt Entity with Table plus apply necessary Database Level Validations

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    // Class which is used to Map the Entity with the Underlying Database Table. Also it performs validation
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        // Primary Key
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        // Basic Properties
        builder.Property(x => x.ProductName).HasColumnName("Name").IsRequired().HasMaxLength(300);
        builder.Property(x => x.UnitPrice).HasColumnName("Price").HasPrecision(18, 2).IsRequired();
        // New Fields
        builder.Property(x => x.DepartmentId).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.BrandId).IsRequired();
        builder.Property(x => x.SKU).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(20).IsRequired();
        // Audit Fields
        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(100);
        builder.Property(x => x.ModifiedOn);
        builder.Property(x => x.ModifiedBy).HasMaxLength(100);
        builder.Property(x => x.IsActive).IsRequired();
    }
}


