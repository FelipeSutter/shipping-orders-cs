using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.ViewModels;

namespace ShippingOrders.Application.Services;
public interface IShippingOrderService {

    Task<string> Add(AddShippingOrderInputModel model);
    Task<ShippingOrderViewModel> GetByCode(string trackingCode);

}
