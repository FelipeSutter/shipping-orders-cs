using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.ViewModels;

namespace ShippingOrders.Application.Services;
public class ShippingOrderService : IShippingOrderService {
    public Task<string> Add(AddShippingOrderInputModel model) {
        throw new NotImplementedException();
    }

    public Task<ShippingOrderViewModel> GetByCode(string trackingCode) {
        throw new NotImplementedException();
    }
}
