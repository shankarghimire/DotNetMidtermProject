using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Passenger
    {
        private int id;
        private int customerId;
        private int flightId;

        public int Id
        {
            get { return id; }
            set { this.id = value; }

        }
        public int CustomerId
        {
            get { return customerId; }
            set { this.customerId = value; }
        }

        public int FlightId
        {
            get { return flightId; }
            set { this.flightId = value; }
        }

        public Passenger()
        {

        }

        public Passenger(int id, int customerId, int flightId)
        {
            Id = id;
            CustomerId = customerId;
            FlightId = flightId;
        }


    }
}
