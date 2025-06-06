using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskStorageService
    {
        private readonly string _storagePath;
        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        public TaskStorageService()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, "TaskManager");
            Directory.CreateDirectory(appFolder);
            _storagePath = Path.Combine(appFolder, "tasks.json");
        }

        public System.Threading.Tasks.Task SaveTasksAsync(IEnumerable<Models.Task> tasks)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(tasks, _jsonSettings);
                File.WriteAllText(_storagePath, jsonString);
                return System.Threading.Tasks.Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save tasks", ex);
            }
        }

        public System.Threading.Tasks.Task<List<Models.Task>> LoadTasksAsync()
        {
            try
            {
                if (!File.Exists(_storagePath))
                {
                    return System.Threading.Tasks.Task.FromResult(new List<Models.Task>());
                }

                string jsonString = File.ReadAllText(_storagePath);
                var tasks = JsonConvert.DeserializeObject<List<Models.Task>>(jsonString, _jsonSettings);
                return System.Threading.Tasks.Task.FromResult(tasks ?? new List<Models.Task>());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load tasks", ex);
            }
        }
    }
} 