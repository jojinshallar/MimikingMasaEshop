using MimikingMasaEshop.Contracts.Catalog.IntegrationEvents;
namespace MimikingMasaEshop.Service.Catalog.Domain.Events;

public record CatalogItemCreatedDomainEvent:CatalogItemCreatedIntegrationEvent,IIntegrationDomainEvent
{
    
}