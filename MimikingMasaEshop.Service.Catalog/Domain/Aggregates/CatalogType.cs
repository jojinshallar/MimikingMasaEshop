namespace MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

public class CatalogType : Enumeration
{
    public static readonly CatalogType Cap = new Cap();
    public static readonly CatalogType Mug = new(2, nameof(Mug));
    public static readonly CatalogType Pin = new(3, nameof(Pin));
    public static readonly CatalogType Sticker = new(4, nameof(Sticker));
    public static readonly CatalogType TShirt = new(5, nameof(TShirt));

    public CatalogType(int id, string name) : base(id, name) { }
    public virtual decimal TotalPrice(decimal price, int num)
    {
        return price * num;
    }
}

public class Cap : CatalogType
{
    public Cap() : base(1, nameof(Cap)) { }

    public override decimal TotalPrice(decimal price, int num)
    {
        return price * num * 0.95m;
    }
}