using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    public class Category
    {
        // A shared static list that holds all created categories in memory
        public static List<Category> AllCategories { get; set; } = new List<Category>();

        // Unique identifier for the category
        public int CategoryID { get; set; }

        // Name or label of the category
        public string CategoryName { get; set; }

        // A list of equipment items that belong to this category (ignored during JSON serialization)
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Equipment> EquipmentList { get; set; } = new List<Equipment>();

        // Default constructor (required for deserialization and general use)
        public Category() { }

        // Constructor to quickly initialize a category with an ID and name
        public Category(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;

            // Automatically add the new category to the global list
            AllCategories.Add(this);
        }

        // Provides a friendly string representation (e.g., "10, Power tools")
        public override string ToString()
        {
            return $"{CategoryID}, {CategoryName}";
        }
    }
}
