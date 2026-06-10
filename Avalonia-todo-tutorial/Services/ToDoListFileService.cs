using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia_todo_tutorial.Models;

namespace Avalonia_todo_tutorial.Services
{
    public static class ToDoListFileService
    {
        private static string _jsonFileName =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Avalonia_todo_tutorial", "MyToDoList.txt");


        public static async Task SaveToFileAsync(IEnumerable<ToDoItem> itemToSave)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);

            using (var fs = File.Create(_jsonFileName))
            {
                await JsonSerializer.SerializeAsync(fs, itemToSave);
            }
        }

        public static async Task<IEnumerable<ToDoItem>?> LoadFromFileAsync()
        {
            try
            {
                using (var fs = File.OpenRead(_jsonFileName))
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<ToDoItem>>(fs);
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                return null;
            }
        }
    }
}
