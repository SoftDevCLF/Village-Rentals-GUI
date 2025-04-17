using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Equipment
    {
        public static List<Equipment> AllEquipment { get; } = new List<Equipment>();

        private int _equipmentID;
        private string _equipmentName;
        private string _equipmentDescription;
        private double _dailyRentalCost;

        public int EquipmentID { get => _equipmentID; set => _equipmentID = value; }
        public Category Category { get; set; }
        public string EquipmentName { get => _equipmentName; set => _equipmentName = value; }
        public string EquipmentDescription { get => _equipmentDescription; set => _equipmentDescription = value; }
        public double DailyRentalCost { get => _dailyRentalCost; set => _dailyRentalCost = value; }

        public Equipment(int equipmentID, Category category, string equipmentName, string equipmentDescription, double dailyRentalCost)
        {
            _equipmentID = equipmentID;
            Category = category;
            _equipmentName = equipmentName;
            _equipmentDescription = equipmentDescription;
            _dailyRentalCost = dailyRentalCost;

            AllEquipment.Add(this);

        }

        //public override string ToString()
        //{
        //    //return $"Equipment ID: {EquipmentID}, Category: {Category.CategoryName}, Name: {EquipmentName}, Description: {EquipmentDescription}, Daily Rental Cost: {DailyRentalCost}";
        //}
    }
}
