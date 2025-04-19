using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public static class DataLoader
    {
        // Load all data from JSON files and rebuild references
        public static void LoadAll()
        {
            // Get the path to the 'Data/Json' folder inside the app's base directory
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            // Build full paths for the category and equipment JSON files
            string categoryPath = Path.Combine(basePath, "Categories.json");
            string equipmentPath = Path.Combine(basePath, "Equipments.json");

            // Load the data from JSON files into lists
            List<Category> loadedCategories = JsonStorageServices.LoadFromJsonSync<Category>(categoryPath);
            List<Equipment> loadedEquipment = JsonStorageServices.LoadFromJsonSync<Equipment>(equipmentPath);

            // Clear the current in-memory category list and add loaded items // LOUIE TO FIX
            //Category.AllCategories.Clear();
            //Category.AllCategories.AddRange(loadedCategories);

            // Clear the current in-memory equipment list and add loaded items
            Equipment.AllEquipment.Clear();
            Equipment.AllEquipment.AddRange(loadedEquipment);

            // Re-link equipment items to shared category references
            RebuildEquipmentCategoryReferences();
        }

        // Save current in-memory data to JSON files
        public static void SaveAll()
        {
            // Define the same directory as where we read the data from
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            // Define full paths to JSON files for categories and equipment
            string categoryPath = Path.Combine(basePath, "Categories.json");
            string equipmentPath = Path.Combine(basePath, "Equipments.json");

            // Save the lists to their respective files
            //JsonStorageServices.SaveToJsonSync(Category.AllCategories, categoryPath); // LOUIE TO FIX
            JsonStorageServices.SaveToJsonSync(Equipment.AllEquipment, equipmentPath);
        }

        // Reconnect Equipment items to their correct shared Category instances
        private static void RebuildEquipmentCategoryReferences()
        {
            foreach (var equipment in Equipment.AllEquipment)
            {
                if (equipment.Category != null)
                {
                    // Find the matching category by ID in the shared Category list
                    //var matched = Category.AllCategories.FirstOrDefault(c => c.CategoryID == equipment.Category.CategoryID); // LOUIE TO FIX

                    // Update the equipment's category reference to the shared one
                    //equipment.Category = matched; // LOUIE TO FIX

                    //if (matched != null) // LOUIE TO FIX
                    {
                        // Also update the Category's internal Equipment list
                        //matched.EquipmentList.Add(equipment); 
                    }
                }
            }
        }
    }
}
