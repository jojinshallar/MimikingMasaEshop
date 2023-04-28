using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimikingMasaEshop.Service.Catalog.Domain.Services
{
    public class CatalogItemDomainService : DomainService
    {
        public CatalogItemDomainService() : base()
        {
        }

        public CatalogItemDomainService(IDomainEventBus eventBus) : base(eventBus)
        {
        }
    }
}