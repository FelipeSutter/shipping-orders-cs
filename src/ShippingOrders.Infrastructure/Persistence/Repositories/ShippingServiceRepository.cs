using MongoDB.Driver;
using ShippingOrders.Core.Entities;
using ShippingOrders.Core.Repositories;

namespace ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingServiceRepository : IShippingServiceRepository
    {

        private readonly IMongoCollection<ShippingService> _collection;

        public ShippingServiceRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public async Task<List<ShippingService>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }
    }
}
