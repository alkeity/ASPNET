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
            ulong id = _tasks.Count != 0 ? _tasks.Max(task => task.Id) + 1 : 0;
            _tasks.Add(new TaskItem { Id = id, Name = name, Description = description });
        }

        public void DeleteTask(ulong id)
        {
            throw new NotImplementedException();
        }

        public void EditTask(ulong id, string name, string? description)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public TaskItem GetTaskById(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
