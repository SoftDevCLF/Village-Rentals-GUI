// File: VillageRentalsGUI/Data/JsonStorageServices.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VillageRentalsGUI.Data
{
    public static class JsonStorageServices
    {
        public static List<T> LoadFromJsonSync<T>(string fileName)
        {
            // DEBUG: Hardcoded path
            string basePath = @"C:\Louie\SAIT SD\CPSY 200 F Software\Village-Rentals-GUI\Data\Json";
            // The paths are not working in the actual Data/Json. I gave up and hardcoded lol
            //string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\Json"));


            Directory.CreateDirectory(basePath);
            string fullPath = Path.Combine(basePath, fileName);

            if (!File.Exists(fullPath))
                return new List<T>();

            string json = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void SaveToJsonSync<T>(List<T> data, string fileName)
        {
            // DEBUG: Hardcoded path
            string basePath = @"C:\Louie\SAIT SD\CPSY 200 F Software\Village-Rentals-GUI\Data\Json";
            // The paths are not working in the actual Data/Json. I gave up and hardcoded lol
            //string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\Json"));


            string fullPath = Path.Combine(basePath, fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fullPath, json);
        }
    }
}