using Homework8_TaskManagerAPI.Data.Models;
using Homework8_TaskManagerAPI.Models.DTO;

namespace Homework8_TaskManagerAPI.Services
{
    public interface ITaskService
    {
        long AddTask(TaskDTO task);

        void DeleteTask(long id);
        List<TaskItem> GetTaskItems();

        TaskItem? GetTaskItem(long id);
    }
}
