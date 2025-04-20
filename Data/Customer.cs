using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageRentalsGUI.Components.Pages;

namespace VillageRentalsGUI.Data
{
    public class Customer
    {
        public static List<Customer> AllCustomers { get; set; } = new(); // Need to assign static

        //public static List<Customer> AllCustomers = new List<Customer>();
        
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBanned { get; set; }  // This is a public auto-property now
        public double Discount { get; set; }

        //public List<Rental> Rentals { get; set; } = new(); Removing this because Rental will live on Rentals page.


        public Customer() { } // Required for JSON serialization

        public Customer(int customerID, string lastName, string firstName, string email, string phoneNumber, bool isBanned=false, double discount=0, bool autoAdd = true)
        {
            CustomerID = customerID;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            IsBanned = isBanned;  
            Discount = discount;

            // Louie: Removing both the static constructor and AllCustomers. I'll use the razor page and serialize from there.
            //if (autoAdd)
            //    AllCustomers.Add(this);  // Adds customer to the AllCustomers list
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
