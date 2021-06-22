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
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        //DataExchange deObj = new DataExchange();
        private CustomAPI customAPIObj = new CustomAPI();

        private List<Flight> flightList;
        public FlightWindow()
        {
            InitializeComponent();

            flightList = customAPIObj.GetFlightList();

            var flightData = from flight in flightList
                             select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;


            lstFlights.DataContext = flightData;
        }

        private void lstFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            int i = lstFlights.SelectedIndex;
            //try
            //{
            //    var selectedItem = lstFlights.SelectedItem.ToString();
            //    MessageBox.Show("selected Item: " + selectedItem);
            //}
            //catch (NullReferenceException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //MessageBox.Show(i.ToString());
            var selectedFlight = from flight in flightList
                                   where flight.Id == (i + 1001)
                                   select flight;
            //Customer temp = (Customer)selectedCustomer;
            //MessageBox.Show(temp.Name);
            foreach (var f in selectedFlight)
            {
                tbFlightId.Text = f.Id.ToString();
                tbAirlineId.Text = f.AirlineId.ToString();

                //MessageBox.Show(c.Name);
                tbDepartureCity.Text = f.DepartureCity;
                tbDestinationCity.Text = f.DestincationCity;
                tbDepartureTime.Text = f.DepartureDate;
                tbFlightTime.Text = f.FlightTime.ToString();

            }
        }

        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            InsertFlightRecord();
            //try
            //{
               
            //    if (tbFlightId.Text == "" || tbAirlineId.Text == "" || tbDepartureCity.Text == "" || tbDestinationCity.Text == "" || tbDepartureTime.Text == "" || tbFlightTime.Text == "")
            //    {
            //        MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    else
            //    {
            //        int fId = int.Parse(tbFlightId.Text);
            //        int newFlightId = int.Parse(tbFlightId.Text);
            //        if (CheckFlightId(fId))
            //        {
            //            MessageBox.Show("Duplicate Flight Id is not allowed! Please, Enter the unique Flight Id.", "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //            tbFlightId.Focus();
            //            return;
            //        }
            //        int airlineId = int.Parse(tbAirlineId.Text);
                    
            //        if (!CheckAirlineId(airlineId))
            //        {
            //            MessageBox.Show("Invalid AirLine Id!, Please, check the Airline Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            //            //tbAirlineId.Focus();
            //            return;

            //        }
            //        string departureCity = tbDepartureCity.Text;
            //        string destinationCity = tbDestinationCity.Text;
            //        string departureDate = tbDepartureTime.Text;
            //        double flightTime = double.Parse( tbFlightTime.Text);

            //        flightList.Add(new Flight(fId, airlineId, departureCity, destinationCity, departureDate, flightTime));
            //        var flightData = from flight in flightList
            //                       select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate+"\t"+flight.FlightTime;

            //        lstFlights.DataContext = flightData;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlightRecord();
            //try
            //{
            //    int fId = int.Parse(tbFlightId.Text);
            //    var flightToUpdate = flightList.Single(flight => flight.Id == fId);

            //    int airlineId = int.Parse(tbAirlineId.Text);
            //    string departureCity = tbDepartureCity.Text;
            //    string destinationCity = tbDestinationCity.Text;
            //    string departureDate = tbDepartureTime.Text;
            //    double flightTime  = double.Parse( tbFlightTime.Text);

            //    flightToUpdate.AirlineId = airlineId;
            //    flightToUpdate.DepartureCity = departureCity;
            //    flightToUpdate.DestincationCity = destinationCity;
            //    flightToUpdate.DepartureDate = departureDate;
            //    flightToUpdate.FlightTime = flightTime;


            //    var flightData = from flight in flightList
            //                     select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

            //    lstFlights.DataContext = flightData;

            //    //de.customerList.Remove(customerToRemove);
            //    //var flightData = from Flight in flightList
            //    //               select Flight.Id + "\t" + Flight.AirlineId + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;

            //    //lstCustomers.DataContext = custData;

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
           
            DeleteFlightRecord();
           
           
        }
        public void ShowCurrentUser()
        {
            //MessageBox.Show(DataExchange.currentUser.Username);
            DateTime now = DateTime.Now;
            lblDate.Content = now;
            lblUsername.Content = "Username : " + DataExchange.currentUser.Username;
            if (DataExchange.currentUser.SuperUser == 1)
            {
                lblUserStatus.Content = "User Status:" + "Super User";
            }
            else
            {
                lblUserStatus.Content = "User Status:" + "Normal User";
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ShowCurrentUser();
            //tbFlightId.IsReadOnly = true;
        }

        private bool CheckAirlineId(int id)
        {
            bool result = false;
            Queue<Airline> tempAirlineList = customAPIObj.GetAirlineQueue();
            var airlineId = from airline in tempAirlineList
                            select airline.Id;
            foreach(var aId in airlineId)
            {
                if(id == aId)
                {
                    result = true;
                    break;
                }
            }
            return result;

        }

        private void tbAirlineId_LostFocus(object sender, RoutedEventArgs e)
        {
            int aId;
            try
            {
                aId = int.Parse(tbAirlineId.Text);
                if (!CheckAirlineId(aId))
                {
                    var result = MessageBox.Show("Invalid AirLine Id!, Please, check the Airline Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private void tbFlightId_LostFocus(object sender, RoutedEventArgs e)
        {
            //int newFlightId = int.Parse(tbFlightId.Text);
            //if (CheckFlightId(newFlightId))
            //{
            //    MessageBox.Show("Duplicate Flight Id is not allowed! Please, Enter the unique Flight Id.", "Data Error",MessageBoxButton.OK, MessageBoxImage.Error);

            //}
        }

        private void ctxMenuInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertFlightRecord();
        }

        private void ctxMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlightRecord();
        }

        private void ctxMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteFlightRecord();
        }

        private void mnuInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertFlightRecord();
        }

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlightRecord();
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteFlightRecord();
        }

        private void DeleteFlightRecord()
        {
            try
            {
                //lstFlights.Items.Clear();
                int fId = int.Parse(tbFlightId.Text);
                var flightToDelete = flightList.Single(flight => flight.Id == fId);
               
                flightList.Remove(flightToDelete);

               
                var flightData = from flight in flightList
                                 select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

                lstFlights.DataContext = flightData;

                tbFlightId.Text = "";
                tbAirlineId.Text = "";
                tbDepartureCity.Text = "";
                tbDestinationCity.Text = "";
                tbDepartureTime.Text = "";
                tbFlightTime.Text = "";
                //result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }
        }

        private void InsertFlightRecord()
        {
            try
            {

                if (tbFlightId.Text == "" || tbAirlineId.Text == "" || tbDepartureCity.Text == "" || tbDestinationCity.Text == "" || tbDepartureTime.Text == "" || tbFlightTime.Text == "")
                {
                    MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    int fId = int.Parse(tbFlightId.Text);
                    int newFlightId = int.Parse(tbFlightId.Text);
                    if (CheckFlightId(fId))
                    {
                        MessageBox.Show("Duplicate Flight Id is not allowed! Please, Enter the unique Flight Id.", "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        tbFlightId.Focus();
                        return;
                    }
                    int airlineId = int.Parse(tbAirlineId.Text);

                    if (!CheckAirlineId(airlineId))
                    {
                        MessageBox.Show("Invalid AirLine Id!, Please, check the Airline Data!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        //tbAirlineId.Focus();
                        return;

                    }
                    string departureCity = tbDepartureCity.Text;
                    string destinationCity = tbDestinationCity.Text;
                    string departureDate = tbDepartureTime.Text;
                    double flightTime = double.Parse(tbFlightTime.Text);

                    flightList.Add(new Flight(fId, airlineId, departureCity, destinationCity, departureDate, flightTime));
                    var flightData = from flight in flightList
                                     select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

                    lstFlights.DataContext = flightData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void UpdateFlightRecord()
        {
            try
            {
                int fId = int.Parse(tbFlightId.Text);
                var flightToUpdate = flightList.Single(flight => flight.Id == fId);

                int airlineId = int.Parse(tbAirlineId.Text);
                string departureCity = tbDepartureCity.Text;
                string destinationCity = tbDestinationCity.Text;
                string departureDate = tbDepartureTime.Text;
                double flightTime = double.Parse(tbFlightTime.Text);

                flightToUpdate.AirlineId = airlineId;
                flightToUpdate.DepartureCity = departureCity;
                flightToUpdate.DestincationCity = destinationCity;
                flightToUpdate.DepartureDate = departureDate;
                flightToUpdate.FlightTime = flightTime;


                var flightData = from flight in flightList
                                 select flight.Id + "\t" + flight.AirlineId + "\t" + flight.DepartureCity + "\t" + flight.DestincationCity + "\t" + flight.DepartureDate + "\t" + flight.FlightTime;

                lstFlights.DataContext = flightData;

                //de.customerList.Remove(customerToRemove);
                //var flightData = from Flight in flightList
                //               select Flight.Id + "\t" + Flight.AirlineId + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;

                //lstCustomers.DataContext = custData;

                //result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }
        }
    }
}
