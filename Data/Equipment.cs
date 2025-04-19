using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Equipment
    {
        // A shared static list that holds all equipment created in memory
        public static List<Equipment> AllEquipment { get; set; } = new List<Equipment>();

        // Private backing fields for encapsulated properties
        private int _equipmentID;
        private string _equipmentName;
        private string _equipmentDescription;
        private double _dailyRentalCost;

        // Public property for Equipment ID with getter and setter
        public int EquipmentID { get => _equipmentID; set => _equipmentID = value; }

        // Category that this equipment belongs to (can be null)
        public Category? Category { get; set; }

        // Name of the equipment
        public string EquipmentName { get => _equipmentName; set => _equipmentName = value; }

        // Description of the equipment
        public string EquipmentDescription { get => _equipmentDescription; set => _equipmentDescription = value; }

        // Daily rental price for this equipment
        public double DailyRentalCost { get => _dailyRentalCost; set => _dailyRentalCost = value; }

        // Default constructor for deserialization and general instantiation
        public Equipment() { }

        // Constructor to create a new equipment item with required fields
        public Equipment(int equipmentID, Category category, string equipmentName, string equipmentDescription, double dailyRentalCost)
        {
            // Prevent duplicate equipment entries based on ID
            if (AllEquipment.Any(e => e.EquipmentID == equipmentID))
                return;

            // Set properties using constructor parameters
            _equipmentID = equipmentID;
            Category = category;
            _equipmentName = equipmentName;
            _equipmentDescription = equipmentDescription;
            _dailyRentalCost = dailyRentalCost;

            // Add to global equipment list
            AllEquipment.Add(this);
        }

        // Provide a readable string representation of the equipment
        public override string ToString()
        {
            return $"Equipment ID: {EquipmentID}, Category: {Category?.CategoryName}, Name: {EquipmentName}, Description: {EquipmentDescription}, Daily Rental Cost: {DailyRentalCost}";
        }
    }

}
