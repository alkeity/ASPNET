using App_ToDoList.Models;
using App_ToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_ToDoList.Pages
{
    public class TaskListModel : PageModel
    {
        private readonly ILogger<TaskListModel> _logger;
        private readonly ITaskService _taskService;

        public List<TaskItem> TaskItems { get; private set; }

        public TaskListModel(ILogger<TaskListModel> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        public void OnGet()
        {
            TaskItems = _taskService.GetAllTasks();
        }
    }
}
