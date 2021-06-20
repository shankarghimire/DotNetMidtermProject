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

        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
