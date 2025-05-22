using System.Collections.Generic;
using App_ToDoList.Models;
using System.Text.Json;

namespace App_ToDoList.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks;

        public TaskService()
        {
            _tasks = new List<TaskItem>();
        }

        public void CreateTask(string name, string description = "")
        {
            _tasks.Add(new TaskItem { Name = name, Description = description });
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }
    }

    public class TaskServiceJson : ITaskService
    {
        private readonly List<TaskItem> _tasks;

        public TaskServiceJson()
        {
            _tasks = new List<TaskItem>();
            if (File.Exists("tasks.json"))
            {
                string tasksStr = File.ReadAllText("tasks.json");
                if (tasksStr != null) _tasks = JsonSerializer.Deserialize<List<TaskItem>>(tasksStr);
            }
        }

        public void CreateTask(string name, string description = "")
        {
            _tasks.Add(new TaskItem { Name = name, Description = description });
            string tasksStr = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tasks.json", tasksStr);
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }
    }
}
