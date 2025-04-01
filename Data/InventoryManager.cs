using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class InventoryManager : Equipment
    {

        public Equipment Equipment { get; set; }

        public InventoryManager(Equipment equipment): base(equipment.EquipmentID, equipment.Category, equipment.EquipmentName, equipment.EquipmentDescription, equipment.DailyRentalCost)
        {
            Equipment = equipment;
            AllEquipment.Add(this); // Add the new item to the inventory
        }

        public static void AddInventoryItem(int equipmentID, int categoryID, string categoryName, string equipmentName, string equipmentDescription, double dailyRentalCost)
        {
            // Create new category with both ID and name
            Category category = new Category(categoryID, categoryName);

            // Create new equipment
            Equipment newEquipment = new Equipment(equipmentID, category, equipmentName, equipmentDescription, dailyRentalCost);

            // Create a new inventory item for the equipment
            new InventoryManager(newEquipment);

            // Optionally, you can print confirmation
            Console.WriteLine($"New Inventory Item Added: {newEquipment.EquipmentName}");
        }

        // Remove inventory item from the list (for example, if sold)
        public static void RemoveInventoryItem(int equipmentID)
        {
            var inventoryItem = AllEquipment.FirstOrDefault(i => i.EquipmentID == equipmentID);
            if (inventoryItem != null)
            {
                AllEquipment.Remove(inventoryItem);
            }
        }

        
    }
}
