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
        public static void LoadAll()
        {
            string basePath = @"C:\Louie\SAIT SD\CPSY 200 F Software\Village-Rentals-GUI\Data\Json";
            // The paths are not working in the actual Data/Json. I gave up and hardcoded lol
            //string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\Json"));


            string customerPath = Path.Combine(basePath, "Customers.json");
            string categoryPath = Path.Combine(basePath, "Categories.json");
            string equipmentPath = Path.Combine(basePath, "Equipments.json");

            List<Category> categoryList = JsonStorageServices.LoadFromJsonSync<Category>("Categories.json");
            List<Equipment> loadedEquipment = JsonStorageServices.LoadFromJsonSync<Equipment>("Equipments.json");
            List<Customer> customersList = JsonStorageServices.LoadFromJsonSync<Customer>("Customers.json");

            Category.categoryList.Clear();
            Category.categoryList.AddRange(categoryList);

            Equipment.AllEquipment.Clear();
            Equipment.AllEquipment.AddRange(loadedEquipment);

            Customer.AllCustomers.Clear();
            Customer.AllCustomers.AddRange(customersList);

            RebuildEquipmentCategoryReferences();
        }

        public static void SaveAll()
        {
            JsonStorageServices.SaveToJsonSync(Customer.AllCustomers, "Customers.json");
            JsonStorageServices.SaveToJsonSync(Category.categoryList, "Categories.json");
            JsonStorageServices.SaveToJsonSync(Equipment.AllEquipment, "Equipments.json");
        }

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
