using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Reports
    {
        // Generate a sales report (e.g., total sales by date)
        public static double SalesByDate(DateTime startDate, DateTime endDate)
        {
            return Rental.AllRentals
                .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
                .Sum(r => r.TotalCost);
        }
        
        public static double SalesByCustomer(int customerID)
        {
            return Rental.AllRentals.Where(r => r.Customer.CustomerID == customerID).Sum(r => r.TotalCost);
        }

        public void ListItemsByCategory(int categoryID)
        {
            var equipmentList = Equipment.AllEquipment.Where(e => e.Category.CategoryID == categoryID).ToList();

            // Loop through each equipment and display its details
            foreach (var equipment in equipmentList)
            {
                Console.WriteLine($"Equipment ID: {equipment.EquipmentID}, Name: {equipment.EquipmentName}, Daily Rental Cost: ${equipment.DailyRentalCost:F2}");
            }

        }

        // Get rentals by customer
        public static List<Rental> GetRentalsByCustomer(int customerID)
        {
            return Rental.AllRentals.Where(r => r.Customer.CustomerID == customerID).ToList();
        }

        // Get rentals by date range
        public static List<Rental> GetRentalsByDateRange(DateTime startDate, DateTime endDate)
        {
            return Rental.AllRentals.Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate).ToList();
        }

        public static double GetTotalSales()
        {
            return Rental.AllRentals.Sum(r => r.TotalCost);
        }


    }
}
