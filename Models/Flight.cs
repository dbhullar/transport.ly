using System;
using System.Collections.Generic;
using System.Linq;

namespace transport.ly
{
    public class Flight
    {
        public int Identifier { get; private set; }
        public int Capacity { get; private set; }
        public int StorageLeft { get; private set; }
        public List<ItineraryItem> Itinerary { get; }
        public List<string> Packages { get; set; }

        public Flight(int identifier, List<ItineraryItem> itinerary, int capacity = 20)
        {            
            Identifier = identifier;            
            this.Itinerary = itinerary;
            Capacity = capacity > 0 ? capacity : 0; // default capacity is 20 boxes
            StorageLeft = Capacity;
            Packages = new List<string>();
        }

        public void PrintItinerary()
        {
            var departureItineraryItem = Itinerary.First();
            var arrivalItineraryItem = Itinerary.Last();            
            Console.WriteLine("Flight: {0}, departure: {1}, arrival: {2}, day: {3}", Identifier, departureItineraryItem.Location, arrivalItineraryItem.Location, departureItineraryItem.Day);            
        }

        public void AddPackage(string packageId)
        {
            if(StorageLeft > 0)
            {
                Packages.Add(packageId);
                StorageLeft--;
            }
        }
    }
}
