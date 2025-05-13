using System.Collections.Generic;
using App_ToDoList.Models;

namespace App_ToDoList.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>()
            {
                new TaskItem() { Name = "Homework", Description = "Do homework" },
                new TaskItem() { Name = "Research", Description = "Research something" },
                new TaskItem() { Name = "Cook", Description = "Food needed" },
                new TaskItem() { Name = "Get your tea", Description = "I forgot to set a timer ooops" },
                new TaskItem() { Name = "Marvelous Designer", Description = "Check how it actually works" },
                new TaskItem() { Name = "Another task", Description = "Do something idk" },
                new TaskItem() { Name = "Never stop being silly" }
            };
        }
    }
}
