// DataLoader.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public static class DataLoader
    {
        // Load all data from JSON files located in the app's local project folder under Data/Json
        public static void LoadAll()
        {
            // Construct a dynamic, cross-platform path relative to the executable's base directory
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            // Define full paths to each file
            string customerPath = Path.Combine(basePath, "Customers.json");
            string categoryPath = Path.Combine(basePath, "Categories.json");
            string equipmentPath = Path.Combine(basePath, "Equipments.json");
            string rentalPath = Path.Combine(basePath, "Rentals.json");

            // Load data from each file
            List<Category> loadedCategories = JsonStorageServices.LoadFromJsonSync<Category>(categoryPath);
            List<Equipment> loadedEquipment = JsonStorageServices.LoadFromJsonSync<Equipment>(equipmentPath);
            List<Customer> loadedCustomers = JsonStorageServices.LoadFromJsonSync<Customer>(customerPath);
            List<Rental> loadedRentals = JsonStorageServices.LoadFromJsonSync<Rental>(rentalPath);

            // Populate in-memory lists
            Category.categoryList.Clear();
            Category.categoryList.AddRange(loadedCategories);

            Equipment.AllEquipment.Clear();
            Equipment.AllEquipment.AddRange(loadedEquipment);

            Customer.AllCustomers.Clear();
            Customer.AllCustomers.AddRange(loadedCustomers);

            Rental.rentalsList.Clear();
            Rental.rentalsList.AddRange(loadedRentals);

            RebuildEquipmentCategoryReferences();
        }

        // Save all in-memory data to their respective JSON files
        public static void SaveAll()
        {
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            JsonStorageServices.SaveToJsonSync(Customer.AllCustomers, Path.Combine(basePath, "Customers.json"));
            JsonStorageServices.SaveToJsonSync(Category.categoryList, Path.Combine(basePath, "Categories.json"));
            JsonStorageServices.SaveToJsonSync(Equipment.AllEquipment, Path.Combine(basePath, "Equipments.json"));
            JsonStorageServices.SaveToJsonSync(Rental.rentalsList, Path.Combine(basePath, "Rentals.json"));
        }

        // Reconnect category references after loading equipment
        private static void RebuildEquipmentCategoryReferences()
        {
            foreach (var equipment in Equipment.AllEquipment)
            {
                if (equipment.Category != null)
                {
                    var matched = Category.categoryList
                        .FirstOrDefault(c => c.CategoryId == equipment.Category.CategoryId);
                    equipment.Category = matched;
                }
            }
        }
    }
}
