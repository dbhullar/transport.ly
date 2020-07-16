using System;
using System.Collections.Generic;
using System.Linq;
using transport.ly.Models;

namespace transport.ly.Services
{
    public class FleetService : IFleetService
    {
        
        public List<Flight> Fleet { get; private set; }

        public FleetService()
        {
        }

        private Flight CreateFlight(int id, int day, Airport from, Airport to)
        {
            return new Flight(id, new List<ItineraryItem>()
                    {
                        new ItineraryItem()
                        { Location = from, Day = day},
                        new ItineraryItem()
                        { Location = to, Day = day }
                    });
        }


        public void ScheduleFleet()
        {
            Fleet = new List<Flight>()
            {
                CreateFlight(1, 1, Airport.YUL, Airport.YYZ),
                CreateFlight(2, 1, Airport.YUL, Airport.YYC),
                CreateFlight(3, 1, Airport.YUL, Airport.YVR),
                CreateFlight(4, 2, Airport.YUL, Airport.YYZ),
                CreateFlight(5, 2, Airport.YUL, Airport.YYC),
                CreateFlight(6, 2, Airport.YUL, Airport.YVR),
            };
        }


        public void ListFlightSchedule()
        {

            Fleet.ForEach(flight => flight.PrintItinerary());
        }

        public void GenerateFlightItineraries(Dictionary<string, Order> orders)
        {
            int countNotAdded = 0;
            foreach (var kvp in orders)
            {
                bool added = false;
                foreach (var flight in Fleet)
                {
                    if (!added && flight.Itinerary.Last().Location == kvp.Value.Destination && flight.StorageLeft > 0)
                    {
                        flight.AddPackage(kvp.Key);
                        Console.WriteLine("order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}",
                            kvp.Key, flight.Identifier, flight.Itinerary.First().Location, flight.Itinerary.Last().Location, flight.Itinerary.First().Day);
                        added = true;
                        
                    }
                }
                if (!added)
                {
                    Console.WriteLine("order: {0}, flightNumber: not scheduled", kvp.Key);
                    countNotAdded++;
                }


            }
            foreach (var flight in Fleet)
            {
                Console.WriteLine("flight {0}, arrival: {1} packages: {2}", flight.Identifier, flight.Itinerary.Last().Location, flight.Packages.Count);
            }

            Console.WriteLine("not scheduled packages: {0}", countNotAdded);
        }
    }
}
