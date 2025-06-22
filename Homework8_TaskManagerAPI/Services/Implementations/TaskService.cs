using Homework8_TaskManagerAPI.Data;
using Homework8_TaskManagerAPI.Data.Models;
using Homework8_TaskManagerAPI.Models.DTO;

namespace Homework8_TaskManagerAPI.Services.Implementations
{
    public class TaskService : ITaskService
    {
        AppDbContext _db;

        public TaskService(AppDbContext db)
        {
            _db = db;
        }
        public void AddTask(TaskDTO task)
        {
            _db.TaskItems.Add(FromDTO(task));
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
