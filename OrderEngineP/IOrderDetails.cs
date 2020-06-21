using System.Collections.Generic;

namespace OrderEngineP
{
    public interface IOrderDetails
    {
        int GetOrderId();
        List<Order> GetOrderList();
    }
}