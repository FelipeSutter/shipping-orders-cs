using MongoDB.Driver;
using ShippingOrders.Core.Entities;
using ShippingOrders.Core.Repositories;

namespace ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingOrderRepository : IShippingOrderRepository
    {

        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrder>("shippingOrders");
        }

        public async Task AddAsync(ShippingOrder shippingOrder)
        {
            await _collection.InsertOneAsync(shippingOrder);
        }

        public async Task<ShippingOrder> GetByCodeAsync(string code)
        {
            return await _collection.Find(c => c.TrackingCode == code).SingleOrDefaultAsync();
        }
    }
}
