using System.Linq.Expressions;
using MimikingMasaEshop.Service.Catalog.Domain.Repositories;
using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;
using MimikingMasaEshop.Service.Catalog.Application.Catalogs.Commands;
using MimikingMasaEshop.Service.Catalog.Application.Catalogs.Queries;
using MimikingMasaEshop.Contracts.Catalog.Dto;

namespace MimikingMasaEshop.Service.Catalog.Application.Catalogs
{
    public class CatalogItemHandler
    {
        private readonly ICatalogItemRepository catalogItemRepository;

        public CatalogItemHandler(ICatalogItemRepository catalogItemRepository)
        {
            this.catalogItemRepository = catalogItemRepository;
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EventHandler]
        public async Task AddAsync(CatalogItemCommand command,CancellationToken cancellationToken){
            var catalogItem=new CatalogItem(command.Name,command.Description,command.Price,command.PictureFileName);
            catalogItem.SetCatalogBrandId(command.CatalogBrandId);
            catalogItem.SetCatalogType(command.CatalogTypeId);
            await catalogItemRepository.AddAsync(catalogItem,cancellationToken);
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EventHandler]
        public async Task GetListAsync(CatalogItemsQuery query,CancellationToken cancellationToken){
            Expression<Func<CatalogItem,bool>> condiction=c=>true;
            condiction=condiction.And(!query.Name.IsNullOrWhiteSpace(),c=>c.Name.Contains(query.Name!));
            var catalogItems=await catalogItemRepository.GetPaginatedListAsync(condiction,new PaginatedOptions(query.Page,query.PageSize),cancellationToken);
            query.Result=new PaginatedListBase<CatalogListItemDto>(){
                Total=catalogItems.Total,
                TotalPages=catalogItems.TotalPages,
                Result=catalogItems.Result.Map<List<CatalogListItemDto>>()
            };
        }
    }
}