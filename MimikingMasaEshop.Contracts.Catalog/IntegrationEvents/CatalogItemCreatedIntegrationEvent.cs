namespace MimikingMasaEshop.Contracts.Catalog.IntegrationEvents;

public record CatalogItemCreatedIntegrationEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }=default!;
    public string Description { get; set; }=default!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; }=default!;
    public int CatalogTypeId { get; set; }
    public Guid CatalogBrandId { get; set; }
    public override string Topic { get; set; } = nameof(CatalogItemCreatedIntegrationEvent);
}