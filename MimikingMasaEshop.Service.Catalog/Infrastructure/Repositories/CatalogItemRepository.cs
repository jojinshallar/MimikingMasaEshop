using MimikingMasaEshop.Service.Catalog.Domain.Repositories;
using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;
using System.Linq.Expressions;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure.Repositories
{
    public class CatalogItemRepository : Repository<CatalogDbContext, CatalogItem, Guid>, ICatalogItemRepository
    {
        private readonly IMultilevelCacheClient _multilevelCacheClient;
        public CatalogItemRepository(CatalogDbContext context, IUnitOfWork unitOfWork, IMultilevelCacheClient multilevelCacheClient) : base(context, unitOfWork)
        {
            _multilevelCacheClient = multilevelCacheClient;
        }

        public override async Task<CatalogItem?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            TimeSpan? timeSpan = null;
            var catalogInfo = await _multilevelCacheClient.GetOrSetAsync(id.ToString(), async () =>
            {
                var info = await Context.Set<CatalogItem>()
                .Include(c => c.CatalogType)
                .Include(c => c.CatalogBrand)
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

                if (info != null)
                {
                    timeSpan = TimeSpan.FromSeconds(30);
                    return new CacheEntry<CatalogItem>(info, TimeSpan.FromDays(3))
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    };
                }

                timeSpan = TimeSpan.FromSeconds(5);
                return new CacheEntry<CatalogItem>(info);
            }, options => options.AbsoluteExpirationRelativeToNow = timeSpan);
            return catalogInfo;
        }

        public override Task<List<CatalogItem>> GetPaginatedListAsync(Expression<Func<CatalogItem, bool>> predicate, int skip, int take, Dictionary<string, bool>? sorting = null, CancellationToken cancellationToken = default)
        {
            sorting ??= new Dictionary<string, bool>();
            return Context.Set<CatalogItem>()
            .Where(predicate)
            .Include(c => c.CatalogBrand)
            .Include(c => c.CatalogType)
            .OrderBy(sorting)
            .Skip(skip).Take(take).ToListAsync(cancellationToken);
        }
    }
}