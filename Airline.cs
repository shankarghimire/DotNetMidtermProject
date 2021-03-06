using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Airline
    {
        private int id;
        private string name;
        private Airplane airplane;
        private int seatsAvailable;
        private MealAvailable mealAvailable;

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public Airplane Airplane
        {
            get { return airplane; }
            set { this.airplane = value; }
        }
        public int SeatAvailable
        {
            get { return seatsAvailable; }
            set { this.seatsAvailable = value; }
        }

        public MealAvailable MealAvailable
        {
            get { return mealAvailable; }
            set { this.mealAvailable = value; }
        }

        public Airline(int id, string name, Airplane airplance, int seatsAvailable, MealAvailable mealAvailable)
        {
            Id = id;
            Name = name;
            Airplane = airplance;
            SeatAvailable = seatsAvailable;
            MealAvailable = mealAvailable;

        }
        
    }

    internal enum MealAvailable
    {
        Chicken,
        Sushi,
        Salad,
        Other
    }

    internal enum Airplane
    {
        Boeing777, Airbus320, Other
    }
}
