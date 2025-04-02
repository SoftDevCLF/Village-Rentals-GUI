using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Rental
    {
        public static List<Rental> AllRentals { get; } = new List<Rental>();

        private int _rentalID;
        private DateTime _currentDate = DateTime.Now;
        private DateTime _rentalDate;
        private DateTime _returnDate;
        private double _totalCost;
        private bool _isReturned;

        public int RentalID { get => _rentalID; set => _rentalID = value; }

        public DateTime CurrentDate { get => _currentDate; set => _currentDate = value; }
        public Customer Customer { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        public DateTime RentalDate { get => _rentalDate; set => _rentalDate = value; }
        public DateTime ReturnDate { get => _returnDate; set => _returnDate = value; }
        public double TotalCost { get => _totalCost; set => _totalCost = value; }
        public bool IsReturned { get => _isReturned; set => _isReturned = value; }

        public Rental(int rentalID, DateTime currentDate, Customer customer, List<Equipment> equipmentList, DateTime rentalDate, DateTime returnDate, bool isReturned = false)
        {
            RentalID = rentalID;
            CurrentDate = currentDate;
            Customer = customer;
            EquipmentList = equipmentList;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;

            customer.Rentals.Add(this);
            AllRentals.Add(this);
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            int rentalDays = (ReturnDate - RentalDate).Days;
            if (rentalDays <= 0) rentalDays = 1; // Ensure at least 1-day cost

            foreach (Equipment equipment in EquipmentList)
            {
                totalCost += equipment.DailyRentalCost * rentalDays;
            }

            if (Customer.Discount > 0)
            {
                totalCost -= (totalCost * Customer.Discount / 100);
            }

            return totalCost;
        }

        public override string ToString()
        {
            string rentalInfo = $"Rental ID: {RentalID}\nCustomer ID: {Customer.CustomerID}, Last Name: {Customer.LastName}\nRental Date: {RentalDate}, Return Date: {ReturnDate}\n";

            int rentalDays = (ReturnDate - RentalDate).Days;
            rentalDays = rentalDays > 0 ? rentalDays : 1;

            foreach (var equipment in EquipmentList)
            {
                double itemCost = equipment.DailyRentalCost * rentalDays;
                rentalInfo += $"Equipment ID: {equipment.EquipmentID}, Name: {equipment.EquipmentName}, Daily rental cost: ${equipment.DailyRentalCost:F2}, Cost for {rentalDays} days: ${itemCost:F2}\n";
            }

            if (Customer.Discount > 0)
            {
                rentalInfo += $"Discount: {Customer.Discount}%\n";
            }

            rentalInfo += $"Total Cost (after discount if applied): ${TotalCost:F2}\n";

            return rentalInfo;
        }
    }
}
