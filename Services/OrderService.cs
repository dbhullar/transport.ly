using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using transport.ly.Models;

namespace transport.ly
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public Dictionary<string, Order> LoadOrders()
        {
            var json = File.ReadAllText(Environment.CurrentDirectory + "/orders.json");
            return JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
        }
    }
}
