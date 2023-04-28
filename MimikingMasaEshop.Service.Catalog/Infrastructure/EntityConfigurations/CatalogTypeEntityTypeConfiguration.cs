using System.Collections.Immutable;
using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure.EntityConfigurations
{
    public class CatalogTypeEntityTypeConfiguration:IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder){
            builder.ToTable(nameof(CatalogType));
            builder.HasKey(c=>c.Id);
            builder.Property(c=>c.Id).IsRequired();
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(100);
        }
    }
}