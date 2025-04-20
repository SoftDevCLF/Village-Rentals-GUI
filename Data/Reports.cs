using System;
using System.Collections.Generic;
using System.Linq;

namespace VillageRentalsGUI.Data
{
    public class Reports
    {
        // Get total sales for a specific date
        public static double SalesByDate(DateTime date)
        {
            return Rental.rentalsList
                .Where(r => r.RentalDate.Date == date.Date)
                .Sum(r => r.TotalCost);
        }

        // Get all rentals on a given date
        public static List<Rental> GetRentalsByDate(DateTime date)
        {
            return Rental.rentalsList
                .Where(r => r.RentalDate.Date == date.Date)
                .ToList();
        }

        // Get total sales for a customer
        public static double SalesByCustomer(int customerID)
        {
            return Rental.rentalsList
                .Where(r => r.CustomerId == customerID)
                .Sum(r => r.TotalCost);
        }

        // Get rentals by customer ID
        public static List<Rental> GetRentalsByCustomer(int customerID)
        {
            return Rental.rentalsList
                .Where(r => r.CustomerId == customerID)
                .ToList();
        }

        // Get customer info by ID (returns list of 1 or 0)
        public static List<Customer> GetCustomerById(int customerID)
        {
            return Customer.AllCustomers
                .Where(c => c.CustomerID == customerID)
                .ToList();
        }

        // Get categories matching a name (case-insensitive)
        public static List<Category> GetCategoriesByName(string categoryName)
        {
            return Category.categoryList
                .Where(c => c.CategoryName.Contains(categoryName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Get total of all rentals in system
        public static double GetTotalSales()
        {
            return Rental.rentalsList.Sum(r => r.TotalCost);
        }

        public static List<Category> GetCategoriesByIdOrName(string input)
        {
            return Category.categoryList
                .Where(c =>
                    c.CategoryName.Contains(input, StringComparison.OrdinalIgnoreCase)
                    || c.CategoryId.ToString().Equals(input))
                .ToList();
        }

        public static List<Rental> GetRentalsByCategory(Category category)
        {
            var equipmentInCategory = Equipment.AllEquipment
                .Where(e => e.CategoryId == category.CategoryId)
                .Select(e => e.EquipmentName)
                .ToList();

            return Rental.rentalsList
                .Where(r => equipmentInCategory.Contains(r.EquipmentName))
                .ToList();
        }



    }
}
