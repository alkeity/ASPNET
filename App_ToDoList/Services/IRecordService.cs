using App_ToDoList.Models;

namespace App_ToDoList.Services
{
    public interface IRecordService
    {
        public void RecordTasks(List<TaskItem> tasks);

        public List<TaskItem> GetAllTasks();
    }
}
