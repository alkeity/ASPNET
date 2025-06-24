using System.Threading.Tasks;
using Homework8_TaskManagerAPI.Data;
using Homework8_TaskManagerAPI.Data.Models;
using Homework8_TaskManagerAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Homework8_TaskManagerAPI.Services.Implementations
{
    public class TaskService : ITaskService
    {
        AppDbContext _db;

        public TaskService(AppDbContext db)
        {
            _db = db;
        }
        public long AddTask(TaskDTO task)
        {
            TaskItem newTask = FromDTO(task);
            _db.TaskItems.Add(newTask);
            _db.SaveChanges();
            return newTask.ID;
        }

        public void DeleteTask(long id)
        {
            _db.TaskItems.Where(task => task.ID == id).ExecuteDelete();
        }

        public TaskItem? GetTaskItem(long id)
        {
            return _db.TaskItems.FirstOrDefault(task => task.ID == id);
        }

        public List<TaskItem> GetTaskItems()
        {
            return _db.TaskItems.ToList();
        }

        private TaskItem FromDTO(TaskDTO task)
        {
            return new TaskItem()
            {
                Title = task.Title,
                Description = task.Description,
                IsDone = task.IsDone,
                CreatedAt = task.CreatedAt
            };
        }
    }
}
