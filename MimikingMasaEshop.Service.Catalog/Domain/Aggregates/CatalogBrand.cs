namespace MimikingMasaEshop.Service.Catalog;

public class CatalogBrand : FullAggregateRoot<Guid, int>
{
    public string Brand { get; private set; } = default!;

    private CatalogBrand(Guid? id = null)
    {
        Id = id ?? IdGeneratorFactory.SequentialGuidGenerator.NewId();
    }

    public CatalogBrand(Guid? id, string brand) : this(id)
    {
        Brand = brand;
    }

    public CatalogBrand(string brand) : this(null, brand)
    {
    }
}