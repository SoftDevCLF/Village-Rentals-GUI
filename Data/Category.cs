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

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        // Empty for Serialization
        public Category () {}

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public override string ToString()
        {
            return $"Category ID: {CategoryId}\n" +
                   $"Category Name: {CategoryName}";

        }

    }


}
