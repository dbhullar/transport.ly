using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using transport.ly.Models;
using transport.ly.Services;

namespace transport.ly
{    
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Tranport.ly");

            // dependencies
            IOrderService orderService = new OrderService();
            IFleetService fleetService = new FleetService();

            var inventoryManager = new InventoryManager(orderService, fleetService);

            // User story 1
            inventoryManager.ListFlightSchedule();

            // User story 2
            inventoryManager.GenerateFlightItineraries();
        }
    }
}
