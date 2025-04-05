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
        public static double SalesByDate(DateTime date)
        {
            return Rental.AllRentals
                .Where(r => r.RentalDate.Date == date.Date)  // Compare only the date part (ignores time)
                .Sum(r => r.TotalCost);
        }

        public static List<Rental> GetRentalsByDate(DateTime date)
        {
            return Rental.AllRentals
                .Where(r => r.RentalDate.Date == date.Date)  // Match rentals on this specific date
                .ToList();
        }

        public static double SalesByCustomer(int customerID)
        {
            return Rental.AllRentals.Where(r => r.Customer.CustomerID == customerID).Sum(r => r.TotalCost);
        }

        public static List<Category> GetCategoriesByName(string categoryName)
        {
            return Category.AllCategories
                .Where(c => c.CategoryName.Contains(categoryName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Get rentals by customer
        public static List<Rental> GetRentalsByCustomer(int customerID)
        {
            return Rental.AllRentals.Where(r => r.Customer.CustomerID == customerID).ToList();
        }

       
        public static double GetTotalSales()
        {
            return Rental.AllRentals.Sum(r => r.TotalCost);
        }


    }
}
