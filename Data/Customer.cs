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
        public static List<Customer> AllCustomers = new List<Customer>();
        
        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBanned { get; set; }  // This is a public auto-property now
        public double Discount { get; set; }
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        static Customer()
        {
            new Customer(1001, "Doe", "John", "jd@sample.net", "(555)555-1212");
            new Customer(1002, "Smith", "Jane", "js@live.com", "(555)555-3434");
            new Customer(1003, "Lee", "Michael", "ml@sample.net", "(555)555-5656");
        }
        public Customer(int? customerID, string lastName, string firstName, string email, string phoneNumber, bool isBanned=false, double discount=0, bool autoAdd = true)
        {
            CustomerID = customerID;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            IsBanned = isBanned;  
            Discount = discount;  

            if (autoAdd)
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
