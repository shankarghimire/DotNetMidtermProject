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
           
            //MessageBox.Show("zz type:" + zz.GetType().FullName + " , " + zz[0]);
            //foreach(var aaa in zz)
            //{
            //    MessageBox.Show("aaa: " + aaa);
            //}
            //MessageBox.Show("zz: " + zz);
            //MessageBox.Show(i.ToString());
            if(i == 0)
            {
                var selectedListItem = lstAirlines.SelectedItem.ToString();
                int id = int.Parse(selectedListItem[0].ToString());

                var selectedAirline = from airline in airlineQueue
                                      where airline.Id == (id )
                                      select airline;
                //Customer temp = (Customer)selectedCustomer;
                //MessageBox.Show(temp.Name);
                foreach (var ap in selectedAirline)
                {
                    tbAirlineId.Text = ap.Id.ToString();
                    tbAirlineName.Text = ap.Name;
                    //MessageBox.Show(c.Name);
                    Airplane apName = ap.Airplane;
                    SetRequiredAirplane(apName);
                    //switch (apName)
                    //{
                    //    case Airplane.Boeing777:
                    //        rdBoeing777.IsChecked = true;
                    //        break;
                    //    case Airplane.Airbus320:
                    //        rdAirbus320.IsChecked = true;
                    //        break;
                    //    case Airplane.Other:
                    //        rdOther.IsChecked = true;
                    //        break;
                    //    default:
                    //        MessageBox.Show("None of the Airplane names are selected!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    //        break;

                    //}
                    tbAvailableSeats.Text = ap.SeatAvailable.ToString();
                    MealAvailable mlAvilable = ap.MealAvailable;
                    SetRequiredMealAvilable(mlAvilable);
                    //switch (mlAvilable)
                    //{
                    //    case MealAvailable.Chicken:
                    //        rdChicken.IsChecked = true;
                    //        break;
                    //    case MealAvailable.Sushi:
                    //        rdSushi.IsChecked = true;
                    //        break;
                    //    case MealAvailable.Salad:
                    //        rdSalad.IsChecked = true;
                    //        break;
                    //    case MealAvailable.Other:
                    //        rdOtherMeal.IsChecked = true;
                    //        break;
                    //    default:
                    //        MessageBox.Show("None of the Meal options are selected!", "Data Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    //        break;
                    //}
                }
            }
            else
            {
                MessageBox.Show("You can only load the top Airline Name due to its Data structure on to the textbox.", "Airline Information", MessageBoxButton.OK, MessageBoxImage.Information);
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
                //string airPlane = tbAirplane.Text;
                Airplane airplaneName = GetSelectedAirplane();
               
                //if(rdBoeing777.IsChecked == true)
                //{
                //    airplaneName = Airplane.Boeing777;
                //}
                //else if(rdAirbus320.IsChecked == true)
                //{
                //    airplaneName = Airplane.Airbus320;
                //}
                //else if (rdOther.IsChecked == true)
                //{
                //    airplaneName = Airplane.Other;
                //}
                int aSeatsAvailable = int.Parse( tbAvailableSeats.Text);
                //string aMeal = tbMealAvailable.Text;
                MealAvailable mealAvailable = GetSelectedMealAvilable() ;
                //if(rdChicken.IsChecked == true)
                //{
                //    mealAvailable = MealAvailable.Chicken;
                //}
                //else if(rdSushi.IsChecked == true)
                //{
                //    mealAvailable = MealAvailable.Sushi;
                //}
                //else if(rdSalad.IsChecked == true)
                //{
                //    mealAvailable = MealAvailable.Salad;
                //}
                //else if (rdOtherMeal.IsChecked == true)
                //{
                //    mealAvailable = MealAvailable.Other;
                //}
                //switch (aMeal)
                //{
                //    case "Chicken":
                //        aMealAvailable = MealAvailable.Chicken;
                //        break;
                //    case "Sushi":
                //        aMealAvailable = MealAvailable.Sushi;
                //        break;
                //    case "Salad":
                //        aMealAvailable = MealAvailable.Salad;
                //        break;
                //    default:
                //        MessageBox.Show("Invalid value for the Meal Available :", "Data Error", MessageBoxButton.OK, MessageBoxImage.Information);
                //        break;
                //}
                
                airlineToUpdate.Name = airlineName;
                airlineToUpdate.Airplane = GetSelectedAirplane();
                airlineToUpdate.SeatAvailable = aSeatsAvailable;
                airlineToUpdate.MealAvailable = GetSelectedMealAvilable();

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

            if (tbAirlineId.Text == "" || tbAirlineName.Text == "" || IsAirplaneNameValid() == false || tbAvailableSeats.Text == "" || IsMealAvailableValid() == false)
            {
                MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int aId = int.Parse(tbAirlineId.Text);
                if(IsAirlineIdValid(aId) == false)
                {
                    MessageBox.Show("AirlineId cannot be repeated!, Please enter a unique Id for AirlineId. ","Data Error",MessageBoxButton
                        .OK, MessageBoxImage.Error);
                    return;
                }

                string aName = tbAirlineName.Text;
                //string  aAirplane= tbAirplane.Text;
                Airplane airplane = GetSelectedAirplane();
                int aSeatsAvailable =int.Parse( tbAvailableSeats.Text);
                //string meal = tbMealAvailable.Text;
                MealAvailable mealAvailable = GetSelectedMealAvilable();
                //MealAvailable aMealAvailable; 
                
                airlineQueue.Enqueue(new Airline(aId, aName, airplane, aSeatsAvailable, mealAvailable));
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
                //
                tbAirlineId.Text = "";
                tbAirlineName.Text = "";
                tbAvailableSeats.Text = "";
                rdAirbus320.IsChecked = false;
                rdBoeing777.IsChecked = false;
                rdOther.IsChecked = false;
                rdChicken.IsChecked = false;
                rdSushi.IsChecked = false;
                rdSalad.IsChecked = false;
                rdOtherMeal.IsChecked = false;

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

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //if (rdBoeing777.IsChecked ==true)
            //{
            //    MessageBox.Show("Selected airplane : " + rdBoeing777.Content);
            //}
            //else if(rdAirbus320.IsChecked == true)
            //{
            //    MessageBox.Show("Selected airplane : " + rdAirbus320.Content);
            //}
            //else if(rdOther.IsChecked == true)
            //{
            //    MessageBox.Show("Selected airplane : " + rdOther.Content);
            //}
            //else
            //{
            //    MessageBox.Show("You should select at least one airplane name : " );
            //}

            if (rdChicken.IsChecked == true)
            {
                MessageBox.Show("Selected Meal : " + rdChicken.Content);
            }
            else if(rdSushi.IsChecked == true)
            {
                MessageBox.Show("Selected Meal : " + rdSushi.Content);
            }
            else if (rdSalad.IsChecked == true)
            {
                MessageBox.Show("Selected Meal : " + rdSalad.Content);
            }
            else if (rdOtherMeal.IsChecked == true)
            {
                MessageBox.Show("Selected Meal : " + rdOtherMeal.Content);
            }


        }

        private bool IsAirplaneNameValid()
        {
            bool result = false;
            if (rdBoeing777.IsChecked == false && rdAirbus320.IsChecked == false && rdOther.IsChecked == false)
            {
                result = false;
            }
            else 
            {
                result = true;
            }
                       
            return result;
        }

        private Airplane GetSelectedAirplane()
        {
            Airplane selectedAirplane = Airplane.Other;
            if(rdBoeing777.IsChecked == true)
            {
                selectedAirplane = Airplane.Boeing777;
            }
            else if(rdAirbus320.IsChecked == true)
            {
                selectedAirplane = Airplane.Airbus320;
            }
            else if(rdOther.IsChecked == true)
            {
                selectedAirplane = Airplane.Other;
            }
            return selectedAirplane;
        }

        private void SetRequiredAirplane(Airplane airplane)
        {
            if(airplane == Airplane.Boeing777)
            {
                rdBoeing777.IsChecked = true;
            }
            else if(airplane == Airplane.Airbus320)
            {
                rdAirbus320.IsChecked = true;
            }
            else if(airplane == Airplane.Other)
            {
                rdOther.IsChecked = true;
            }
        }

        private bool IsMealAvailableValid()
        {
            bool result = false;
            if(rdChicken.IsChecked == false && rdSushi.IsChecked == false && rdSalad.IsChecked == false && rdOtherMeal.IsChecked == false)
            {
                result = false;
            }
            else
            {
                result = true;
            }


            return result;
        }
        private MealAvailable GetSelectedMealAvilable()
        {
            MealAvailable mealAvailable = MealAvailable.Other;
            if(rdChicken.IsChecked == true)
            {
                mealAvailable = MealAvailable.Chicken;
            }
            else if(rdSushi.IsChecked == true)
            {
                mealAvailable = MealAvailable.Sushi;
            }
            else if(rdSalad.IsChecked == true)
            {
                mealAvailable = MealAvailable.Salad;
            }
            else if(rdOtherMeal.IsChecked == true)
            {
                mealAvailable = MealAvailable.Other;
            }
            return mealAvailable;
        }

        private void SetRequiredMealAvilable(MealAvailable mealAvilable)
        {
            if(mealAvilable == MealAvailable.Chicken)
            {
                rdChicken.IsChecked = true;
            }
            else if(mealAvilable == MealAvailable.Sushi)
            {
                rdSushi.IsChecked = true;
            }
            else if(mealAvilable == MealAvailable.Salad)
            {
                rdSushi.IsChecked = true;
            }
            else if(mealAvilable == MealAvailable.Other)
            {
                rdOtherMeal.IsChecked = true;
            }
        }

        private bool IsAirlineIdValid(int id)
        {
            bool result = true;
            var airlineIds = from airline in airlineQueue
                      select airline.Id;
            foreach(var aId in airlineIds)
            {
                if(id == aId)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
