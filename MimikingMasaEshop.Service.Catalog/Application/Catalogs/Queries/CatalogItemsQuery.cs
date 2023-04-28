using MimikingMasaEshop.Contracts.Catalog.Dto;
using MimikingMasaEshop.Contracts.Catalog.Request;

namespace MimikingMasaEshop.Service.Catalog.Application.Catalogs.Queries
{
    public record CatalogItemsQuery:ItemsQueryBase<PaginatedListBase<CatalogListItemDto>>
    {
        public string? Name { get; set; }
        public override PaginatedListBase<CatalogListItemDto> Result{get;set;}=default!;
    }
}