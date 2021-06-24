using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TakeHomeMidterm
{
    /// <summary>
    /// Interaction logic for PassengerWindow.xaml
    /// </summary>
    public partial class PassengerWindow : Window
    {
        //DataExchange deObj = new DataExchange();
        private CustomAPI customAPIObj = new CustomAPI();
        private Stack<Passenger> passengerStack;

        private List<Customer> customerList = new List<Customer>();
        private List<Flight> flightList = new List<Flight>();

        public PassengerWindow()
        {
            InitializeComponent();
            
            customerList = customAPIObj.GetCustomerList();
            flightList = customAPIObj.GetFlightList();

            passengerStack = customAPIObj.GetPassengerStack();


            //List<Passenger> topPassenger = new List<Passenger>();
            //topPassenger.Add(passengerStack.Peek());
            var passengerData = from passenger in passengerStack
                                select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId ;

            lstPassengers.DataContext = passengerData;
        }

        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstPassengers.SelectedIndex;
            //MessageBox.Show("i=" + i);
            //MessageBox.Show(i.ToString());
            if( i == 0)
            {
                List<Passenger> topPassenger = new List<Passenger>();
                topPassenger.Add(passengerStack.Peek());

                foreach (var p in topPassenger)
                {
                    tbPassengerId.Text = p.Id.ToString();
                    tbCustomerId.Text = p.CustomerId.ToString();
                    tbFlightId.Text = p.FlightId.ToString();
                }
            }
            else
            {
                MessageBox.Show("You can only load the top-stack element on to the textbox.","Stack Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
           
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            InsertPassengerRecord();

            //try
            //{

            //    if (tbPassengerId.Text == "" || tbCustomerId.Text == "" || tbFlightId.Text == "" )
            //    {
            //        MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    else
            //    {
            //        int pId = int.Parse(tbPassengerId.Text);
            //        if (CheckPassengerId(pId))
            //        {
            //            MessageBox.Show("Duplicate Passenger Id is not allowed! Please, Enter the unique Passenger Id.", "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //            tbFlightId.Focus();
            //            return;
            //        }

            //        int cId = int.Parse(tbCustomerId.Text);
            //        if (!CheckCustomerId(cId))
            //        {
            //            MessageBox.Show("Invalid Customer Id!, Please, check the Customer Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            //            //tbAirlineId.Focus();
            //            return;

            //        }


            //        int fId = int.Parse(tbFlightId.Text);
            //        if (!CheckFlightId(fId))
            //        {
            //            MessageBox.Show("Invalid Flight Id!, Please, check the Flight Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            //            //tbAirlineId.Focus();
            //            return;

            //        }
                   
                 
            //        passengerStack.Push(new Passenger(pId, cId, fId));
            //        var passengerData = from passenger in passengerStack
            //                         select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;

            //        lstPassengers.DataContext = passengerData;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassengerRecord();

            //try
            //{
            //    int pId = int.Parse(tbPassengerId.Text);
            //    var passengerToUpdate = passengerStack.Single(passenger => passenger.Id == pId);

            //    int customerId = int.Parse(tbCustomerId.Text);
            //    int flightId = int.Parse(tbFlightId.Text);

            //    passengerToUpdate.CustomerId = customerId;
            //    passengerToUpdate.FlightId = flightId;

            //    var passengerData = from passenger in passengerStack
            //                        select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;

            //    lstPassengers.DataContext = passengerData;


            //    //result = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            //    //result = false;
            //}
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeletePassengerRecord();

            //try
            //{
            //    //int fId = int.Parse(tbFlightId.Text);
            //    //var flightToDelete = flightList.Single(flight => flight.Id == fId);
            //    //flightList.Remove(flightToDelete);
            //    passengerStack.Pop();
            //    var passengerData = from passenger in passengerStack
            //                        select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;


            //    lstPassengers.DataContext = passengerData;
            //    tbPassengerId.Text = "";
            //    tbCustomerId.Text = "";
            //    tbFlightId.Text = "";

            //    //var flightData = from flight in flightList
            //    //                 select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

            //    //lstFlights.DataContext = flightData;
            //    //result = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            //    //result = false;
            //}
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Hide();
                    //this.Close();
                    //System.Environment.Exit(0);
                }
           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CheckPassengerId(int id)
        {
            bool result = false;

            //List<Flight> tempAirlineList = deObj.GetAirlineList();
            var passengerId = from passenger in passengerStack
                           select passenger.Id;
            foreach (var pId in passengerId)
            {
                if (id == pId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool CheckCustomerId(int id)
        {
            bool result = false;

            //List<Flight> tempAirlineList = deObj.GetAirlineList();
            var customerId = from customer in customerList
                           select customer.Id;
            foreach (var cId in customerId)
            {
                if (id == cId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        private bool CheckFlightId(int id)
        {
            bool result = false;

            //List<Flight> tempAirlineList = deObj.GetAirlineList();
            var flightId = from flight in flightList
                           select flight.Id;
            foreach (var fId in flightId)
            {
                if (id == fId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void ctxMenuInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertPassengerRecord();
        }

        private void ctxMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassengerRecord();
        }

        private void ctxMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeletePassengerRecord();
        }

        private void InsertPassengerRecord()
        {

            try
            {

                if (tbPassengerId.Text == "" || tbCustomerId.Text == "" || tbFlightId.Text == "")
                {
                    MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    int pId = int.Parse(tbPassengerId.Text);
                    if (CheckPassengerId(pId))
                    {
                        MessageBox.Show("Duplicate Passenger Id is not allowed! Please, Enter the unique Passenger Id.", "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        tbFlightId.Focus();
                        return;
                    }

                    int cId = int.Parse(tbCustomerId.Text);
                    if (!CheckCustomerId(cId))
                    {
                        MessageBox.Show("Invalid Customer Id!, Please, check the Customer Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        //tbAirlineId.Focus();
                        return;

                    }


                    int fId = int.Parse(tbFlightId.Text);
                    if (!CheckFlightId(fId))
                    {
                        MessageBox.Show("Invalid Flight Id!, Please, check the Flight Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        //tbAirlineId.Focus();
                        return;

                    }


                    passengerStack.Push(new Passenger(pId, cId, fId));
                    var passengerData = from passenger in passengerStack
                                        select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;

                    lstPassengers.DataContext = passengerData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdatePassengerRecord()
        {

            try
            {
                var result = MessageBox.Show("Are you sure to update this record? ", "Update Confirmation Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int pId = int.Parse(tbPassengerId.Text);
                    var passengerToUpdate = passengerStack.Single(passenger => passenger.Id == pId);

                    int customerId = int.Parse(tbCustomerId.Text);
                    int flightId = int.Parse(tbFlightId.Text);

                    passengerToUpdate.CustomerId = customerId;
                    passengerToUpdate.FlightId = flightId;

                    var passengerData = from passenger in passengerStack
                                        select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;

                    lstPassengers.DataContext = passengerData;

                    //result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }
        }

        private void DeletePassengerRecord()
        {

            try
            {
                var result = MessageBox.Show("Are you sure to delete this record? ", "Delete Confirmation Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    //int fId = int.Parse(tbFlightId.Text);
                    //var flightToDelete = flightList.Single(flight => flight.Id == fId);
                    //flightList.Remove(flightToDelete);
                    passengerStack.Pop();
                    var passengerData = from passenger in passengerStack
                                        select passenger.Id + "\t" + passenger.CustomerId + "\t" + passenger.FlightId;


                    lstPassengers.DataContext = passengerData;
                    tbPassengerId.Text = "";
                    tbCustomerId.Text = "";
                    tbFlightId.Text = "";

                    //var flightData = from flight in flightList
                    //                 select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

                    //lstFlights.DataContext = flightData;
                    //result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }
        }

        private void mnuInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertPassengerRecord();
        }

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassengerRecord();
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeletePassengerRecord();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Hide();
                    //this.Close();
                    //System.Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AboutUs aboutUs = new AboutUs();
                aboutUs.Title = "About System Information";
                aboutUs.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mnuViewPassengers.IsEnabled = false;

            if (CustomAPI.currentUser.UserStatus == UserStatus.RegularUser)
            {
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnAddNew.IsEnabled = false;
                mnuDelete.IsEnabled = false;
                mnuUpdate.IsEnabled = false;
                mnuInsert.IsEnabled = false;
                ctxMenuDelete.IsEnabled = false;
                ctxMenuUpdate.IsEnabled = false;
                ctxMenuInsert.IsEnabled = false;
            }
        }

        private void mnuViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow();
            customerWindow.Title = "Customer Information";
            customerWindow.ShowDialog();
        }

        private void mnuViewFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow flightWindow = new FlightWindow();
            flightWindow.Title = "Flight Information";
            flightWindow.ShowDialog();
        }

        private void mnuViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            AirlineWindow airlineWindow = new AirlineWindow();
            airlineWindow.Title = "Airline Information";
            airlineWindow.ShowDialog();
        }
    }
}
