using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    [Serializable]

    public class Category
    {

        // Global Category List
        public static List<Category> categoryList { get; set; } = new(); // Need to assign static
        //public List<Category> categoryList = new List<Category>();

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        // Empty for Serialization
        public Category () {}

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        // Provides a friendly string representation (e.g., "10, Power tools")
        public override string ToString()
        {
            return $"Category ID: {CategoryId}\n" +
                   $"Category Name: {CategoryName}";

        }

    }


}
