using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class DataExchange
    {
        private List<Customer> customerList = new List<Customer>();
        //private List<Airline> airlineList = new List<Airline>();
        public static Logins currentUser = new Logins();

        private List<Flight> flightList = new List<Flight>();

        private Stack<Passenger> pasengerStack = new Stack<Passenger>();

        public Queue<Airline> airlineQueue = new Queue<Airline>();
         public DataExchange()
        {
            //Add Customers Data
            customerList.Add(new Customer(101, "Shankar Ghimire", "Brampton", "sg@gmail.com", "123-444-5555"));
            customerList.Add(new Customer(102, "Harry Smith", "Brampton", "hs@gmail.com", "123-333-4444"));
            customerList.Add(new Customer(103, "Mike Steve", "Brampton", "ms@gmail.com", "123-555-6666"));
            customerList.Add(new Customer(104, "Rama Ghimire", "Brampton", "rg@gmail.com", "123-666-7777"));
            customerList.Add(new Customer(105, "Sam Ghimire", "Brampton", "samg@gmail.com", "123-777-8888"));

            //Add Airline List
            //airlineList.Add(new Airline(1, "Canada Airways", "Boeing 777", 360, MealAvailable.Chicken));
            //airlineList.Add(new Airline(2, "Quatar Airways", "Boeing 888", 500, MealAvailable.Salad));
            //airlineList.Add(new Airline(3, "American Airways", "Airbus 777", 670, MealAvailable.Sushi));
            //airlineList.Add(new Airline(4, "British Airways", "Boeing 999", 540, MealAvailable.Sushi));
            //airlineList.Add(new Airline(5, "South China Airways", "Boeing 777", 260, MealAvailable.Chicken));

            //Add Flight List
            flightList.Add(new Flight(1001, 1, "Toronto","Kathmandu","2021/06/20", 16.0));
            flightList.Add(new Flight(1002, 1, "Edmonton", "Kathmandu", "2021/06/20", 20.0));
            flightList.Add(new Flight(1003, 2, "Montreal", "Kathmandu", "2021/06/20", 20.0));
            flightList.Add(new Flight(1004, 2, "Kathmandu", "Toronto", "2021/06/20", 16.0));
            flightList.Add(new Flight(1005, 3, "Kathmandu", "Montreal", "2021/06/20", 20.0));



            //add element to the Queue
            airlineQueue.Enqueue(new Airline(1, "Canada Airways", Airplane.Boeing777, 360, MealAvailable.Chicken));
            airlineQueue.Enqueue(new Airline(2, "Quatar Airways", Airplane.Boeing777, 500, MealAvailable.Salad));
            airlineQueue.Enqueue(new Airline(3, "American Airways", Airplane.Airbus320, 670, MealAvailable.Sushi));
            airlineQueue.Enqueue(new Airline(4, "British Airways", Airplane.Airbus320, 540, MealAvailable.Sushi));
            airlineQueue.Enqueue(new Airline(5, "South China Airways",Airplane.Other, 260, MealAvailable.Chicken));


            //Add customers into passengerStack
            pasengerStack.Push(new Passenger(1, 101, 1001));
            pasengerStack.Push(new Passenger(2, 102, 1002));
            pasengerStack.Push(new Passenger(3, 103, 1002));
            pasengerStack.Push(new Passenger(4, 104, 1001));
            pasengerStack.Push(new Passenger(5, 105, 1003));

        }

        public void saveCurrentUser(Logins logins)
        {
            currentUser = logins;
        }

        public void AddFlight( Flight flight)
        {
            flightList.Add(flight);
        }

        public List<Flight> GetFlightList()
        {
            return flightList;
        }

        public List<Customer> GetCustomerList()
        {
            return customerList;
        }

        //public List<Airline> GetAirlineList()
        //{
        //    return airlineList;
        //}
        public Queue<Airline> GetAirlineQueue()
        {
            return airlineQueue;
        }
        public Stack<Passenger> GetPassengerStack()
        {
            return pasengerStack;
        }

        public bool SavePassengerToStack(Passenger newPassenger)
        {
            bool result = false;
            try
            {
                pasengerStack.Push(newPassenger);
                result = true;
            }
            catch(Exception ex)
            {
                
                //MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;

            }
            return result;
        }

        public Passenger GetPassengerTopOnStack()
        {
            Passenger temp ;
            try
            {
                temp= pasengerStack.Pop();
            }
            catch(Exception ex)
            {

                temp = null;
            }
            return temp;
        }

        //public bool UpdatePassenger(Passenger p)
        //{
        //    bool result = false;


        //    return result;
        //}
    }
}
