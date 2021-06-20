using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class DataExchange
    {
        public List<Customer> customerList = new List<Customer>();
        public List<Airline> airlineList = new List<Airline>();
         public DataExchange()
        {
            //Add Customers Data
            customerList.Add(new Customer(101, "Shankar Ghimire", "Brampton", "sg@gmail.com", "123-444-5555"));
            customerList.Add(new Customer(102, "Harry Smith", "Brampton", "hs@gmail.com", "123-333-4444"));
            customerList.Add(new Customer(103, "Mike Steve", "Brampton", "ms@gmail.com", "123-555-6666"));
            customerList.Add(new Customer(104, "Rama Ghimire", "Brampton", "rg@gmail.com", "123-666-7777"));
            customerList.Add(new Customer(105, "Sam Ghimire", "Brampton", "samg@gmail.com", "123-777-8888"));

            //Add Airline List
            airlineList.Add(new Airline(1, "Canada Airways","Boeing 777",360,MealAvailable.Chicken));
            airlineList.Add(new Airline(2, "Quatar Airways", "Boeing 888", 500, MealAvailable.Salad));
            airlineList.Add(new Airline(3, "American Airways", "Airbus 777", 670, MealAvailable.Sushi));
            airlineList.Add(new Airline(4, "British Airways", "Boeing 999", 540, MealAvailable.Sushi));
            airlineList.Add(new Airline(5, "South China Airways", "Boeing 777", 260, MealAvailable.Chicken));


        }

    }
}
