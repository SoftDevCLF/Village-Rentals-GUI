using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Customer
    {
        public static List<Customer> AllCustomers { get; set; } = new List<Customer>();

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBanned { get; set; }  // This is a public auto-property now
        public double Discount { get; set; }
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public Customer(int customerID, string lastName, string firstName, string email, string phoneNumber, bool isBanned, double discount)
        {
            CustomerID = customerID;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            IsBanned = isBanned;  // No reset of value here
            Discount = discount;  // No reset of value here

            AllCustomers.Add(this);  // Adds customer to the AllCustomers list
        }

        public override string ToString() 
        {
            string status = "";
            if (IsBanned == true)
            {
                status = "Banned";
            }

            else
            {
                status = "Not Banned";
            }

            return $"Customer ID: {CustomerID}\n" +
                   $"First Name: {FirstName}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Status: {status}\n" +
                   $"Discount: {Discount}%";
        }

    }
}
