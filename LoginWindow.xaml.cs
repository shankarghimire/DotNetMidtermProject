﻿using System;
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

        private List<Logins> loginList = new List<Logins>();
        private Dictionary<string, Logins> usersDictionary = new Dictionary<string, Logins>();

        private MainWindow mainWindow = new MainWindow();

        public LoginWindow()
        {
            InitializeComponent();

            //Console.WriteLine(st);
            loginList.Add(new Logins(101, "Admin", "test", 1));
            loginList.Add(new Logins(102, "Shankar", "test", 1));
            loginList.Add(new Logins(103, "Test1", "test", 0));
            loginList.Add(new Logins(104, "Test2", "test", 0));
            loginList.Add(new Logins(105, "Test3", "test", 0));

            //Adding to Dictionary
            foreach(var user in loginList)
            {
                string userName = user.Username;
                usersDictionary.Add(userName, user);
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            userName = tbUsername.Text;
            password = pbPassword.Password;
            if(userName.Length == 0 )
            {
                MessageBox.Show("Username cannot be blank!", "Login Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbUsername.Focus();
                return;
            }
            if ( password.Length == 0)
            {
                MessageBox.Show("Password cannot be blank!", "Login Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                pbPassword.Focus();
                return;
            }

            if (usersDictionary.ContainsKey(userName))
            {
                Logins temp = usersDictionary[userName];
                if(password == temp.Password)
                {
                    MainWindow m = new MainWindow();
                    DataExchange dataExchangeObj1 = new DataExchange();
                    dataExchangeObj1.saveCurrentUser(temp);
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

        private void tbnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                //this.Close();
                System.Environment.Exit(0);
            }
            else
            {
                //e.Cancel = true;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsername.Focus();
            tbUsername.Text = "Admin";
            pbPassword.Password = "test";
            
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var result = MessageBox.Show("Are you sure to quit the program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    //this.Close();
            //    System.Environment.Exit(0);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}

        }
    }
}
