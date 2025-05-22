using System.Text.Json;
using System.Threading.Tasks;
using App_ToDoList.Models;

namespace App_ToDoList.Services.Implementations
{
    public class RecordServiceJson : IRecordService
    {
        private string filePath = "Database/tasks.json";

        public List<TaskItem> GetAllTasks()
        {
            if (File.Exists(filePath))
            {
                string tasksStr = File.ReadAllText(filePath);
                List<TaskItem> tasks = JsonSerializer.Deserialize<List<TaskItem>>(tasksStr);
                return tasks != null ? tasks : new List<TaskItem>();
            }
            return new List<TaskItem>();
        }

        public void RecordTasks(List<TaskItem> tasks)
        {
            string tasksStr = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, tasksStr);
        }
    }
}
