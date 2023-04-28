using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure.EntityConfigurations
{
    public class CatalogBrandEntityTypeConfiguration:IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder){
            builder.ToTable(nameof(CatalogBrand));
            builder.HasKey(c=>c.Id);
            builder.Property(c=>c.Id).IsRequired();
            builder.Property(c=>c.Brand).IsRequired().HasMaxLength(100);
        }
    }
}