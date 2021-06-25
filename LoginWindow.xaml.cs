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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private string userName = "Test";
        private string password="test";
        private DataExchange de = new DataExchange();
        private CustomAPI customAPI = new CustomAPI();
        private List<Logins> loginList = new List<Logins>();
        private Dictionary<string, Logins> usersDictionary = new Dictionary<string, Logins>();

        private MainWindow mainWindow = new MainWindow();

        public LoginWindow()
        {
            try 
            {
                InitializeComponent();

                //Console.WriteLine(st);
                loginList.Add(new Logins(101, "Admin", "test", UserStatus.SuperUser));
                loginList.Add(new Logins(102, "Shankar", "test", UserStatus.SuperUser));
                loginList.Add(new Logins(103, "User1", "test", UserStatus.RegularUser));
                loginList.Add(new Logins(104, "User2", "test", UserStatus.RegularUser));
                loginList.Add(new Logins(105, "User3", "test", UserStatus.RegularUser));

                //Adding to Dictionary
                foreach (var user in loginList)
                {
                    string userName = user.Username;
                    usersDictionary.Add(userName, user);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userName = tbUsername.Text;
                password = pbPassword.Password;
                if (userName.Length == 0)
                {
                    MessageBox.Show("Username cannot be blank!", "Login Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbUsername.Focus();
                    return;
                }
                if (password.Length == 0)
                {
                    MessageBox.Show("Password cannot be blank!", "Login Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    pbPassword.Focus();
                    return;
                }

                if (usersDictionary.ContainsKey(userName))
                {
                    Logins temp = usersDictionary[userName];
                    if (password == temp.Password)
                    {
                        MainWindow m = new MainWindow();
                        DataExchange dataExchangeObj1 = new DataExchange();
                        dataExchangeObj1.saveCurrentUser(temp);
                        customAPI.saveCurrentUser(temp);
                        //de.currentUser.Id = temp.Id;
                        //de.currentUser.Username = temp.Username;
                        //de.currentUser.Password = temp.Password;
                        //de.currentUser.SuperUser = temp.SuperUser;
                        //MessageBox.Show(de.currentUser.Username);
                        m.Background = Brushes.Azure;
                        m.Title = "Home Page";
                        m.Show();
                        this.Hide();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        pbPassword.Focus();
                        pbPassword.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Username!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }           

        }

        private void tbnCancel_Click(object sender, RoutedEventArgs e)
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
                    //e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                    
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tbUsername.Focus();
                //tbUsername.Text = "Admin";
                //pbPassword.Password = "test";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                      
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            
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
    }
}
