using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

namespace MimikingMasaEshop.Service.Catalog.Application.Catalogs.Commands
{
    public class CatalogItemCommandValidator : AbstractValidator<CatalogItemCommand>
    {
        public CatalogItemCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().Length(1, 20).WithMessage("商品名称长度介于1-20之间");
            RuleFor(c => c.CatalogTypeId).Must(typeId => Enumeration.GetAll<CatalogType>().Any(item => item.Id == typeId)).WithMessage("不支持的商品分类");
        }
    }
}