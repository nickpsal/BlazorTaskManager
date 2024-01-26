using System.Text.Json;
using TaskManager.Data;

namespace TaskManager.Services
{
    public class HandleJson : IHandleJson
    {
        private static readonly string JsonPath = "Data/tasks.json";

        public async Task deleteTask(UserTask taskdorDeleted)
        {
            List<UserTask> tasks = readJsonData();
            tasks.RemoveAll(task => task.TaskName == taskdorDeleted.TaskName);
            await exporttoJson(tasks);
        }

        public async Task exporttoJson(List<UserTask> tasks)
        {
            // Read the existing JSON data from the file
            string existingData = await File.ReadAllTextAsync(JsonPath);
            // Configure JsonSerializer settings to include line breaks
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true, // This ensures the output is formatted with indentation
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            // Serialize the updated list of UserTask objects to JSON
            string updatedData = JsonSerializer.Serialize(tasks, options);
            // Write the updated JSON data back to the file
            await File.WriteAllTextAsync(JsonPath, updatedData);
        }

        public List<UserTask> readJsonData()
        {
            // Read the JSON data from the file
            string jsonData = File.ReadAllText(JsonPath);
            // Deserialize the JSON data into a list of UserTask objects
            List<UserTask> tasks = JsonSerializer.Deserialize<List<UserTask>>(jsonData)!;
            return tasks!;
        }

        public async Task savetoJson(UserTask newTask)
        {
            // Read the existing JSON data from the file
            string existingData = await File.ReadAllTextAsync(JsonPath);
            // Deserialize the existing JSON data into a list of UserTask objects
            List<UserTask> existingTasks = JsonSerializer.Deserialize<List<UserTask>>(existingData) ?? new List<UserTask>();
            existingTasks.Add(newTask);
            // Configure JsonSerializer settings to include line breaks
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true, // This ensures the output is formatted with indentation
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            // Serialize the updated list of UserTask objects to JSON
            string updatedData = JsonSerializer.Serialize(existingTasks, options);
            // Write the updated JSON data back to the file
            await File.WriteAllTextAsync(JsonPath, updatedData);
        }

        public async Task UpdateTask(UserTask oldTask, UserTask updateTask)
        {
            List<UserTask> tasks = readJsonData();
            tasks.RemoveAll(task => task.TaskName == oldTask.TaskName);
            tasks.Add(updateTask);
            await exporttoJson(tasks);
        }
    }
}
