using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Commands;

namespace MimikingMasaEshop.Service.Catalog.Application.Catalogs.Commands
{
    public record CatalogItemCommand : Command
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PictureFileName { get; set; } = default!;
        public Guid CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }

    }
}