using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QST.ECommerce.Domain.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Infrastructure.Configurations
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //throw new NotImplementedException();
            //builder.HasKey()
            builder.ToTable("Brand");
            builder.HasKey(x => x.Id); // Primary Key (Not Null, Not Duplicate)
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);
        }
    }
}
