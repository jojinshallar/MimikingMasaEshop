using Mapster;
using MimikingMasaEshop.Contracts.Catalog.Dto;
using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure
{
    public static class GlobalMappingConfig
    {
        public static void Mapping()
        {
            MappingCatalogItemToCatalogListItemDto();
        }

        private static void MappingCatalogItemToCatalogListItemDto()
        {
            TypeAdapterConfig<CatalogItem, CatalogListItemDto>
            .NewConfig()
            .Map(dst => dst.CatalogTypeName, c => c.CatalogType.Name)
            .Map(dst => dst.CatalogBrandName, c => c.CatalogBrand.Brand);
        }
    }
}