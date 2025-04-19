using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VillageRentalsGUI.Data
{
    using System.Text.Json;

    public static class JsonStorageServices
    {
        // Loads a list of objects of type T from a JSON file located in the Data/Json folder
        public static List<T> LoadFromJsonSync<T>(string fileName)
        {
            // Base path points to your project directory's Data/Json folder
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            // Ensure the folder exists
            Directory.CreateDirectory(basePath);

            // Full path to the target JSON file
            string fullPath = Path.Combine(basePath, fileName);

            // Return an empty list if the file does not exist
            if (!File.Exists(fullPath))
                return new List<T>();

            // Read the file contents
            string json = File.ReadAllText(fullPath);

            // Deserialize into a list of objects
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // Saves a list of objects of type T to a JSON file in the Data/Json folder
        public static void SaveToJsonSync<T>(List<T> data, string fileName)
        {
            // Base path pointing to your project directory's Data/Json folder
            string basePath = Path.Combine(AppContext.BaseDirectory, "Data", "Json");

            // Ensure the directory exists
            Directory.CreateDirectory(basePath);

            // Full path to write the JSON file
            string fullPath = Path.Combine(basePath, fileName);

            // Serialize the data into pretty-printed JSON
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // Write to the file
            File.WriteAllText(fullPath, json);
        }
    }

}
