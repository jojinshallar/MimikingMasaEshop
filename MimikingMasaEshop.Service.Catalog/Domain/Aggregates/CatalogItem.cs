using MimikingMasaEshop.Service.Catalog.Domain.Events;

namespace MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

public class CatalogItem : FullAggregateRoot<Guid, int>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; } = default;
    public string PictureFileName { get; private set; } = default!;
    public int CatalogTypeId { get; private set; }
    public CatalogType CatalogType { get; private set; } = default!;
    public Guid CatalogBrandId { get; private set; }
    public CatalogBrand CatalogBrand { get; private set; } = default!;
    public int AvailableStock { get; private set; }
    public int RestockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }

    public CatalogItem(Guid? id = null)
    {
        Id = id ?? IdGeneratorFactory.GuidGenerator.NewId();
    }

    public CatalogItem(string name, string description, decimal price, string pictureFileName) : this()
    {
        Name = name;
        Description = description;
        Price = price;
        PictureFileName = pictureFileName;
        AddCatalogItemDoaminEvent();
    }

    public void SetCatalogType(int catalogTypeId)
    {
        CatalogTypeId = catalogTypeId;
    }

    public void SetCatalogBrandId(Guid catalogBrandId){
        CatalogBrandId=catalogBrandId;
    }

    private void AddCatalogItemDoaminEvent(){
        var domainEvent=this.Map<CatalogItemCreatedDomainEvent>();
        domainEvent.CatalogBrandId=CatalogBrandId;
        domainEvent.CatalogTypeId=CatalogTypeId;
        AddDomainEvent(domainEvent);
    }
}