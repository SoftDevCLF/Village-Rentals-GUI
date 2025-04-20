using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    // Louie: Cintya, I kept your code. I just need a clean slate for me to work on. Then I will integrate whatever your reports code is.
    public class Rental
    {
        //List for Json loaded elements
        public static List<Rental> rentalsList { get; set; } = new(); // Need to assign static

        // Variable Initialization
        public int RentalID { get; set; }

        public double TotalCost { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        // Customer and Equipment Variables
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string EquipmentName { get; set; }

        public int CustomerId { get; set; }

        // Parameter-less constructor to make `new Rental()` work
        public Rental() { }


        public string formattedDate;

        //string formattedDate = date1.ToString("dd MMM yyyy");

        public Rental(int rentalId, DateTime dateCreated, DateTime rentalDate, DateTime returnDate, double totalCost, string customerFirstName, string customerLastName, string equipmentName, int customerId)
        {
            RentalID = rentalId;
            DateCreated = dateCreated;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            TotalCost = totalCost;

            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            EquipmentName = equipmentName;
            CustomerId = customerId;
        }


    }
}
