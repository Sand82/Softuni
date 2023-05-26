using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{ 
    public class AirlinesManager : IAirlinesManager
    {
        private List<Airline> airlineList = new List<Airline>();

        private Dictionary<string, Airline> airlineDictionary = new Dictionary<string, Airline>();

        private Dictionary<string, Flight> flightsDictionary = new Dictionary<string, Flight>();

        private List<Flight> performedFlights = new List<Flight>();

        public void AddAirline(Airline airline)
        {
            if (!airlineDictionary.ContainsKey(airline.Id))
            {
                airlineDictionary.Add(airline.Id, airline);
                airlineList.Add(airline);
            }
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            CheckForAirline(airline.Id);            

            airline.Flights.Add(flight.Id, flight);

            if (!flightsDictionary.ContainsKey(flight.Id))
            {
                flightsDictionary.Add(flight.Id, flight);
            }            
        }

        public bool Contains(Airline airline)
        {
            return airlineDictionary.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flightsDictionary.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            CheckForAirline(airline.Id);

            foreach (var flight in airline.Flights)
            {
                flightsDictionary.Remove(flight.Value.Id);
            }

            airlineDictionary.Remove(airline.Id);
            airlineList.Remove(airline);
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flightsDictionary.Values;
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            CheckForAirline(airline.Id);
            CheckForFlight(flight.Id);

            var currFlight = airline.Flights[flight.Id];

            currFlight.IsCompleted = true;

            performedFlights.Add(flight);

            return currFlight;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return performedFlights;
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            if (flightsDictionary.Count == 0)
            {
                return new List<Flight>();
            }

            return flightsDictionary.Values.OrderBy(x => x.IsCompleted).ThenBy(x => x.Number).ToList();
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            if (airlineDictionary.Count == 0)
            {
                return new List<Airline>();
            }

            return airlineDictionary
                .Values
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Flights.Values.Count)
                .ThenBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            var result = new List<Airline>();

            if (airlineDictionary.Count == 0)
            {
                return result;
            }

            foreach (var airline in airlineList)
            {
                foreach (var flight in airline.Flights)
                {
                    if (flight.Value.IsCompleted == true && flight.Value.Destination == destination && flight.Value.Origin == origin)
                    {
                        result.Add(airline);
                        break;
                    }
                }
            }

            return result;
        }    

        private void CheckForFlight(string id)
        {
            if (!flightsDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }

        public void CheckForAirline(string id)
        {
            if (!airlineDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }        
    }
}