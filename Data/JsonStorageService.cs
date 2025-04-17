using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VillageRentalsGUI.Data
{
    public class JsonStorageService
    {
        private readonly string basePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", "data");

        // Change basePath from the .exe location to another.
        //private readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;

        public void SaveToJsonSync<T>(List<T> list, string fileName)
        {

            //Ensure directory exists
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            string path = Path.Combine(basePath, fileName);
            string jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        public List<T> LoadFromJsonSync<T>(string fileName)
        {
            string path = Path.Combine(basePath, fileName);
            if (!File.Exists(path))
                return new List<T>();

            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        }
    }
}