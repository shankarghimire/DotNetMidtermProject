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
    /// Interaction logic for AirlineWindow.xaml
    /// </summary>
    public partial class AirlineWindow : Window
    {
        private DataExchange deObj = new DataExchange();
        //private List<Airline> airlineList = new List<Airline>();

        private Queue<Airline> airlineQueue = new Queue<Airline>();

        public AirlineWindow()
        {
            InitializeComponent();
            airlineQueue = deObj.GetAirlineQueue();
            var airlineData = from airline in airlineQueue
                               select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;
            lstAirlines.DataContext = airlineData;


        }

        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstAirlines.SelectedIndex;        
            //MessageBox.Show(i.ToString());
            if(i == 0)
            {
                var selectedAirline = from airline in airlineQueue
                                      where airline.Id == (i + 1)
                                      select airline;
                //Customer temp = (Customer)selectedCustomer;
                //MessageBox.Show(temp.Name);
                foreach (var ap in selectedAirline)
                {
                    tbAirlineId.Text = ap.Id.ToString();
                    tbAirlineName.Text = ap.Name;
                    //MessageBox.Show(c.Name);
                    tbAirplane.Text = ap.Airplane;
                    tbAvailableSeats.Text = ap.SeatAvailable.ToString();
                    tbMealAvailable.Text = ap.MealAvailable.ToString();
                }
            }
            else
            {
                MessageBox.Show("You can only load the top-Queue element on to the textbox.", "Queue Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //bool result = false;
            try
            {
                int aId = int.Parse(tbAirlineId.Text);
                var airlineToUpdate = airlineQueue.Single(air => air.Id == aId);

                string airlineName = tbAirlineName.Text;
                string airPlane = tbAirplane.Text;
                int aSeatsAvailable = int.Parse( tbAvailableSeats.Text);
                string aMeal = tbMealAvailable.Text;
                MealAvailable aMealAvailable = MealAvailable.None;
                switch (aMeal)
                {
                    case "Chicken":
                        aMealAvailable = MealAvailable.Chicken;
                        break;
                    case "Sushi":
                        aMealAvailable = MealAvailable.Sushi;
                        break;
                    case "Salad":
                        aMealAvailable = MealAvailable.Salad;
                        break;
                    default:
                        MessageBox.Show("Invalid value for the Meal Available :", "Data Error", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
                
                airlineToUpdate.Name = airlineName;
                airlineToUpdate.Airplane = airPlane;
                airlineToUpdate.SeatAvailable = aSeatsAvailable;
                airlineToUpdate.MealAvailable = aMealAvailable;

                //de.customerList.Remove(customerToRemove);
                var airlineData = from airline in airlineQueue
                                  select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
                //result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Eror Message",MessageBoxButton.OK,MessageBoxImage.Error);
                    
                //result = false;
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {

            if (tbAirlineId.Text == "" || tbAirlineName.Text == "" || tbAirplane.Text == "" || tbAvailableSeats.Text == "" || tbMealAvailable.Text == "")
            {
                MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int aId = int.Parse(tbAirlineId.Text);
                string aName = tbAirlineName.Text;
                string  aAirplane= tbAirplane.Text;
                int aSeatsAvailable =int.Parse( tbAvailableSeats.Text);
                string meal = tbMealAvailable.Text;
                MealAvailable aMealAvailable;
                switch (meal)
                {
                    case "Chicken":
                        aMealAvailable = MealAvailable.Chicken;
                        break;
                    case "Sushi":
                        aMealAvailable = MealAvailable.Sushi;
                        break;
                    case "Salad":
                        aMealAvailable = MealAvailable.Salad;
                        break;
                    default:
                        aMealAvailable = MealAvailable.None;
                        break;

                }

                airlineQueue.Enqueue(new Airline(aId, aName, aAirplane, aSeatsAvailable, aMealAvailable));
                var airlineData = from airline in airlineQueue
                                  select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int aId = int.Parse(tbAirlineId.Text);
                //var airlineToDelete = airlineQueue.Single(air => air.Id == aId);

                airlineQueue.Dequeue();

                //de.customerList.Remove(customerToRemove);
                var airlineData = from airline in airlineQueue
                                  select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
                //result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }
        }


        private void ShowCurrentUser()
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
        }
    }
}
