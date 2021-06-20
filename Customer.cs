using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Customer
    {
        private int id;
        private string name;
        private string address;
        private string email;
        private string phone;
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { this.phone = value; }
        }

        public Customer()
        {

        }

        public Customer(int id, string name, string address, string email, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
