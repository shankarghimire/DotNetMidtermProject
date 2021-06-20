using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Flight
    {
        private int id;
        private int airlineId;
        private string departureCity;
        private string destinationCity;
        private string departureDate;
        private double flightTime;

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public int AirlineId
        {
            get { return airlineId; }
            set { this.airlineId = value; }
        }

        public string DepartureCity
        {
            get { return departureCity; }
            set { this.departureCity = value; }
        }

        public string DestincationCity
        {
            get { return destinationCity; }
            set { this.destinationCity = value; }
        }

        public string DepartureDate
        {
            get { return departureCity; }
            set { this.departureDate = value; }
        }
        
        public double FlightTime
        {
            get { return flightTime; }
            set { this.flightTime = value; }
        }

        public Flight()
        {

        }
        public Flight(int id, int airlineId, string departureCity, string destincationCity, string departureDate, double flightTime)
        {
            Id = id;
            AirlineId = airlineId;
            DepartureCity = departureCity;
            DestincationCity = destincationCity;
            DepartureDate = departureDate;
            FlightTime = flightTime;
        }
             
    }
}
