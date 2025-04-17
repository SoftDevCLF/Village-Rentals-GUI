using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    // Handles logic related to managing equipment inventory
    public class InventoryManager
    {
        // Reference to the equipment being managed
        public Equipment Equipment { get; set; }

        // Constructor to wrap an existing Equipment object
        public InventoryManager(Equipment equipment)
        {
            Equipment = equipment;
        }

        // Adds a new equipment item to the system
        public static void AddInventoryItem(int equipmentID, int categoryID, string categoryName, string equipmentName, string equipmentDescription, double dailyRentalCost)
        {
            // Try to find an existing category by ID
            Category? category = Category.AllCategories.FirstOrDefault(c => c.CategoryID == categoryID);

            // If category doesn't exist, create and add it
            if (category == null)
            {
                category = new Category(categoryID, categoryName);
                Category.AllCategories.Add(category);
            }

            // Create a new Equipment instance with the found or created category
            Equipment newEquipment = new Equipment(equipmentID, category, equipmentName, equipmentDescription, dailyRentalCost);

            // Wrap it in an InventoryManager if needed (not strictly necessary)
            new InventoryManager(newEquipment);

            // Optional debug log
            Console.WriteLine($"New Inventory Item Added: {newEquipment.EquipmentName}");
        }

        // Removes an equipment item from the system by ID
        public static void RemoveInventoryItem(int equipmentID)
        {
            Equipment? inventoryItem = Equipment.AllEquipment.FirstOrDefault(i => i.EquipmentID == equipmentID);
            if (inventoryItem != null)
            {
                Equipment.AllEquipment.Remove(inventoryItem);
            }
        }
    }
}
