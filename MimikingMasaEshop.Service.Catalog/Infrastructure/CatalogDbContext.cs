using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimikingMasaEshop.Service.Catalog.Infrastructure
{
    public class CatalogDbContext : MasaDbContext<CatalogDbContext>
    {
        public CatalogDbContext(MasaDbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreatingExecuting(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
            base.OnModelCreatingExecuting(modelBuilder);
        }
    }
}