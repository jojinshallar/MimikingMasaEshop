namespace MimikingMasaEshop.Service.Catalog.Application.Catalogs.Queries
{
    public class CatalogItemQueryValidator:AbstractValidator<CatalogItemsQuery>
    {
        public CatalogItemQueryValidator()
        {
            RuleFor(x=>x.Page).GreaterThanOrEqualTo(1).WithMessage("页码错误");
            RuleFor(x=>x.PageSize).GreaterThan(0).WithMessage("页大小错误");
        }
    }
}