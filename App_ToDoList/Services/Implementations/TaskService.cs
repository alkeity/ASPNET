using System.Collections.Generic;
using App_ToDoList.Models;

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
}
