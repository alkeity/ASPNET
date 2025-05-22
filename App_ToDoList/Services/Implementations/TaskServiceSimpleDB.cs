using App_ToDoList.Models;

namespace App_ToDoList.Services.Implementations
{
    public class TaskServiceSimpleDB : ITaskService
    {
        private IRecordService _recordService;
        private List<TaskItem> _tasks;

        public TaskServiceSimpleDB(IRecordService recordService)
        {
            _recordService = recordService;
            _tasks = _recordService.GetAllTasks();
        }
        public void CreateTask(string name, string description = "")
        {
            ulong id = _tasks.Count != 0 ? _tasks.Max(task => task.Id) + 1 : 0;
            _tasks.Add(new TaskItem { Id = id, Name = name, Description = description });
            _recordService.RecordTasks(_tasks);
        }

        public void DeleteTask(ulong id)
        {
            int index = _tasks.FindIndex(task => task.Id == id);
            if (index != -1)
            {
                _tasks.RemoveAt(index);
                _recordService.RecordTasks(_tasks);
            }
        }

        public void EditTask(ulong id, string name, string? description)
        {
            int index = _tasks.FindIndex(task => task.Id == id);
            if (index != -1)
            {
                _tasks[index].Name = name;
                _tasks[index].Description = description;
                _recordService.RecordTasks(_tasks);
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public TaskItem GetTaskById(ulong id)
        {
            return _tasks.Find(task => task.Id == id);
        }
    }
}
