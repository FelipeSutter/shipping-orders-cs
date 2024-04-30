using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.ViewModels;
using ShippingOrders.Core.Entities;
using ShippingOrders.Core.ValueObjects;
using System.Text.Json;

namespace ShippingOrders.Application.Services;
public class ShippingOrderService : IShippingOrderService {

    public Task<string> Add(AddShippingOrderInputModel model) {
        var shippingOrder = model.ToEntity();
        var shippingServices =  model.Services.Select(s => s.ToEntity()).ToList();
        shippingOrder.SetupServices(shippingServices);


        Console.WriteLine(JsonSerializer.Serialize(shippingOrder));

        return Task.FromResult(shippingOrder.TrackingCode);

    }

    public Task<ShippingOrderViewModel> GetByCode(string trackingCode) {
        var shippingOrder = new ShippingOrder(
            "Pedido 1",
            1.3m,
            new DeliveryAddress("Rua A", "1A", "12345-678", "São paulo", "SP", "Brasil")
        );

        return Task.FromResult(ShippingOrderViewModel.FromEntity(shippingOrder));

    }
}
