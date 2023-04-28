namespace MimikingMasaEshop.Contracts.Catalog.Dto;

public class CatalogListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }=default!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; }=default!;
    public int CatalogTypeId { get; set; }
    public string CatalogTypeName { get; set; }=default!;
    public Guid CatalogBrandId { get; set; }
    public string CatalogBrandName { get; set; }=default!;
    public int AvailableStock { get; set; }
}