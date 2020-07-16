using System.Collections.Generic;
using transport.ly.Models;

namespace transport.ly
{
    public interface IOrderService
    {
        public Dictionary<string, Order> LoadOrders();
    }
}
