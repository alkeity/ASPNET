using App_ToDoList.Models;

namespace App_ToDoList.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();
        public void CreateTask(string name, string? description);
        public TaskItem GetTaskById(ulong id);
        public void EditTask(ulong id, string name, string? description);
        public void DeleteTask(ulong id);
    }
}
