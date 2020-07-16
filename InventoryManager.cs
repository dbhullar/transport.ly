using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using transport.ly.Models;
using transport.ly.Services;

namespace transport.ly
{
    public class InventoryManager
    {
        Dictionary<string, Flight> Schedule = new Dictionary<string, Flight>();

        private IOrderService orderService;
        private IFleetService fleetService;

        public InventoryManager(IOrderService orderService, IFleetService fleetService)
        {
            this.orderService = orderService;
            this.fleetService = fleetService;
        }

        public void ListFlightSchedule()
        {
            fleetService.ScheduleFleet();
            fleetService.ListFlightSchedule();            
        }

        public void GenerateFlightItineraries()
        {
            fleetService.ScheduleFleet();
            var orders = orderService.LoadOrders();
            fleetService.GenerateFlightItineraries(orders);            
        }
    }
}
