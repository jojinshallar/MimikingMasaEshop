using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimikingMasaEshop.Service.Catalog.Domain.Aggregates;

namespace MimikingMasaEshop.Service.Catalog.Domain.Repositories
{
    public interface ICatalogItemRepository:IRepository<CatalogItem,Guid>
    {
        
    }
}