using Homework8_TaskManagerAPI.Data.Models;
using Homework8_TaskManagerAPI.Models.DTO;

namespace Homework8_TaskManagerAPI.Services
{
    public interface ITaskService
    {
        void AddTask(TaskDTO task);
        List<TaskItem> GetTaskItems();
    }
}
