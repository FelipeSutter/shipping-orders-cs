using MongoDB.Driver;
using ShippingOrders.Core.Entities;

namespace ShippingOrders.Infrastructure.Persistence
{
    public class DbSeed
    {

        private readonly IMongoCollection<ShippingService> _collection;

        // Os objetos que serão populados no banco
        private List<ShippingService> _shippingServices = new List<ShippingService>
        {
            new ShippingService("Envio estadual", 3.75m, 12),
            new ShippingService("Envio internacional", 5.25m, 15),
            new ShippingService("Caixa tamanho P", 0, 5),
        };

        // Pega a collection 'shippingServices' do banco
        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shippingServices");
        }

        // Método para popular o banco de dados caso não tenha registros na tabela de shippingServices.
        public void Populate()
        {
            if (_collection.CountDocuments(c => true) == 0)
                _collection.InsertMany(_shippingServices);
        }

    }
}
