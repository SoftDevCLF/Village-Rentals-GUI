using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Category
    {
        public static List<Category> AllCategories { get; } = new List<Category>();
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Equipment> EquipmentList { get; set; } = new List<Equipment>();

        public Category(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;

            AllCategories.Add(this);
        }

        public override string ToString()
        {
            return $"{CategoryID}, {CategoryName}";
        }
    }
}
