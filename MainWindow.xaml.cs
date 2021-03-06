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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TakeHomeMidterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Logins> loginList = new List<Logins>();
        //private List<Customer> customerList = new List<Customer>();
        private DataExchange de = new DataExchange();
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //Method call to initialize customers
                //customerList.Add(new Customer(101, "Shankar Ghimire","Brampton","sg@gmail.com","123-444-5555"));
                //customerList.Add(new Customer(102, "Harry Smith", "Brampton", "hs@gmail.com", "123-333-4444"));
                //customerList.Add(new Customer(103, "Mike Steve", "Brampton", "ms@gmail.com", "123-555-6666"));
                //customerList.Add(new Customer(104, "Rama Ghimire", "Brampton", "rg@gmail.com", "123-666-7777"));
                //customerList.Add(new Customer(105, "Sam Ghimire", "Brampton", "samg@gmail.com", "123-777-8888"));

                //foreach(var cust in de.customerList)
                //{
                //    MessageBox.Show(cust.Name);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

          
            

        }

       
        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //this.Close();
                    System.Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

         
            
            
        }

        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void btnViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewCustomerWindow();
                //CustomerWindow cw = new CustomerWindow();                    
                //cw.Background = Brushes.AliceBlue;
                //cw.Title = "View Customers";
                //cw.ShowDialog();
                //this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void ShowViewCustomerWindow()
        {
            try
            {
                CustomerWindow cw = new CustomerWindow();
                cw.Background = Brushes.AliceBlue;
                cw.Title = "View Customers";
                cw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btnViewFlights_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewFlightWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void ShowViewFlightWindow()
        {
            try
            {
                FlightWindow fw = new FlightWindow();
                fw.Background = Brushes.AliceBlue;
                fw.Title = "View Flights";
                fw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

        private void btnViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewAirlineWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ShowViewAirlineWindow()
        {
            try
            {
                AirlineWindow aw = new AirlineWindow();
                aw.Background = Brushes.AliceBlue;
                aw.Title = "View Airlines";
                aw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }
        private void btnViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewPassengerWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private void ShowViewPassengerWindow()
        {
            try
            {
                PassengerWindow pw = new PassengerWindow();
                pw.Background = Brushes.AliceBlue;
                pw.Title = "View Passengers";
                pw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        //private void Window_Initialized(object sender, EventArgs e)
        //{

        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            { //MessageBox.Show(DataExchange.currentUser.Username);
                DateTime now = DateTime.Now;
                lblDate.Content = now;
                lblUsername.Content = "Username : " + DataExchange.currentUser.Username;
                if (CustomAPI.currentUser.UserStatus == UserStatus.SuperUser)
                {
                    lblUserStatus.Content = "User Status:" + "Super User";
                }
                else
                {
                    lblUserStatus.Content = "User Status:" + "Normal User";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    //this.Close();
                    System.Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        //private void mnuHelp_Click_1(object sender, RoutedEventArgs e)
        //{

        //}

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

        private void mnuViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewCustomerWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
           
        }

        private void mnuViewFlights_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewFlightWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void mnuViewAirlines_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewAirlineWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void mnuViewPassengers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowViewPassengerWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }











        //public List<Logins> LoginList
        //{
        //    get { return loginList; }
        //    //set { this.loginList = value; }
        //}


    }
}
