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
        private DataExchange de = new DataExchange();
        public AirlineWindow()
        {
            InitializeComponent();
            var airlineData = from airline in de.airlineList
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
            var selectedAirline = from airline in de.airlineList
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //bool result = false;
            try
            {
                int aId = int.Parse(tbAirlineId.Text);
                var airlineToUpdate = de.airlineList.Single(air => air.Id == aId);

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
                var airlineData = from airline in de.airlineList
                               select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
                //result = true;
            }
            catch (Exception ex)
            {
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
                string aSeatsAvailable = tbAvailableSeats.Text;
                string aMealAvailable = tbMealAvailable.Text;
                de.customerList.Add(new Customer(aId, aName, aAirplane, aSeatsAvailable, aMealAvailable));
                var airlineData = from airline in de.airlineList
                               select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int aId = int.Parse(tbAirlineId.Text);
                var airlineToDelete = de.airlineList.Single(air => air.Id == aId);

                de.airlineList.Remove(airlineToDelete);

                //de.customerList.Remove(customerToRemove);
                var airlineData = from airline in de.airlineList
                                  select airline.Id + "\t" + airline.Name + "\t" + airline.Airplane + "\t" + airline.SeatAvailable + "\t" + airline.MealAvailable;

                lstAirlines.DataContext = airlineData;
                //result = true;
            }
            catch (Exception ex)
            {
                //result = false;
            }
        }
    }
}
