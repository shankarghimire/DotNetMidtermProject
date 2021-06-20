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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    
    public partial class CustomerWindow : Window
    {
        //public static List<Customer> listCustomers = new List<Customer>();
        //public void getData(List<Customer> listCust)
        //{

        //}
        private DataExchange deObj = new DataExchange();

        private List<Customer> customerList = new List<Customer>();
        //private Logins currentUser;
        public CustomerWindow()
        {
            InitializeComponent();
            customerList = deObj.GetCustomerList();
            //currentUser = DataExchange.currentUser;
            var custData = from cust in customerList
                           select cust.Id + "\t" + cust.Name + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;
            

            lstCustomers.DataContext = custData;
        }

        private void lstCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstCustomers.SelectedIndex;
            //MessageBox.Show(i.ToString());
            var selectedCustomer = from cust in customerList
                                   where cust.Id == (i + 101)
                                   select cust;
            //Customer temp = (Customer)selectedCustomer;
            //MessageBox.Show(temp.Name);
            foreach(var c in selectedCustomer)
            {
                tbCustomerId.Text = c.Id.ToString();
                tbCustomerName.Text = c.Name;
                //MessageBox.Show(c.Name);
                tbCustomerAddress.Text = c.Address;
                tbCustomerEmail.Text = c.Email;
                tbCustomerPhone.Text = c.Phone;
               
            }
        }

        private void mnuFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //foreach(var c in de.customerList)
            //{
            //    MessageBox.Show(c.Name);
            //}
            //DateTime now = DateTime.Now;
            //lblDate.Content = now;
            //lblUsername.Content = de.currentUser.Username;
            //if(de.currentUser.SuperUser == 1)
            //{
            //    lblUserStatus.Content = "Super User";
            //}
            //else
            //{
            //    lblUserStatus.Content = "Normal User";
            //}

            //lblUserStatus.Content = "Super";
              //  de.currentUser.SuperUser == 1 ? lblUserStatus.Content = "Super User" : lblUserStatus.Content = "Normal User";


        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            if(tbCustomerId.Text == "" || tbCustomerName.Text == "" || tbCustomerAddress.Text == "" ||tbCustomerEmail.Text == "" || tbCustomerPhone.Text == "")
            {
                MessageBox.Show("All the fields are mandatory!", "Data Validation Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int cId = int.Parse(tbCustomerId.Text);
                string cName = tbCustomerName.Text;
                string cAdr = tbCustomerAddress.Text;
                string cEmail = tbCustomerEmail.Text;
                string cPhone = tbCustomerPhone.Text;
                customerList.Add(new Customer(cId, cName, cAdr, cEmail, cPhone ));
                var custData = from cust in customerList
                               select cust.Id + "\t" + cust.Name + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;

                lstCustomers.DataContext = custData;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //bool result = false;
            try
            {
                int cId = int.Parse(tbCustomerId.Text);
                var customerToUpdate = customerList.Single(cust => cust.Id == cId);
                
                string cName = tbCustomerName.Text;
                string cAdr = tbCustomerAddress.Text;
                string cEmail = tbCustomerEmail.Text;
                string cPhone = tbCustomerPhone.Text;
                customerToUpdate.Name = cName;
                customerToUpdate.Address = cAdr;
                customerToUpdate.Email = cEmail;
                customerToUpdate.Phone = cPhone;

                //de.customerList.Remove(customerToRemove);
                var custData = from cust in customerList
                               select cust.Id + "\t" + cust.Name + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;

                lstCustomers.DataContext = custData;
                //result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cId = int.Parse(tbCustomerId.Text);
                var customerToDelete = customerList.Single(cust => cust.Id == cId);

                customerList.Remove(customerToDelete);

                //de.customerList.Remove(customerToRemove);
                var custData = from cust in customerList
                               select cust.Id + "\t" + cust.Name + "\t" + cust.Address + "\t" + cust.Email + "\t" + cust.Phone;

                lstCustomers.DataContext = custData;
                //result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                //result = false;
            }

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ShowCurrentUser();
        }
        //public CustomerWindow( List<Customer>customerList)
        //{
        //    InitializeComponent();
        //}

        //public void LoadCustomerRecords(List<Customer> customersList)
        //{

        //}

        private void ShowCurrentUser()
        {
            MessageBox.Show(DataExchange.currentUser.Username);
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
    
    }
}
