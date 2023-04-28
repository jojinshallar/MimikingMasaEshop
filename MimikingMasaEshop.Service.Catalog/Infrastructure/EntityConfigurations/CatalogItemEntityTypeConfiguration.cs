using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure.EntityConfigurations
{
    public class CatalogItemEntityTypeConfiguration:IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)        {
            builder.ToTable(nameof(CatalogItem).Replace("Item",""));
            builder.Property(c=>c.Id).IsRequired();
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c=>c.Price).IsRequired();
            builder.Property(c=>c.PictureFileName).IsRequired(false);
            builder.HasOne(c=>c.CatalogBrand).WithMany().HasForeignKey(c=>c.CatalogBrandId);
            builder.HasOne(c=>c.CatalogType).WithMany().HasForeignKey(c=>c.CatalogTypeId);
        }
    }
}