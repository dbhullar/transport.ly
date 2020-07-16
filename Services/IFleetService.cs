using System.Collections.Generic;
using transport.ly.Models;

namespace transport.ly.Services
{
    public interface IFleetService
    {
        public void ScheduleFleet();
        public void ListFlightSchedule();
        public void GenerateFlightItineraries(Dictionary<string, Order> orders);
    }
}