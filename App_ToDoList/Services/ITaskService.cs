using App_ToDoList.Models;

namespace App_ToDoList.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();
    }
}
