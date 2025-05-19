using App_ToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_ToDoList.Pages.Tasks
{
    public class TaskEditModel : PageModel
    {
        private readonly ITaskService _taskService;
        public TaskEditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _taskService.CreateTask(Request.Form["title"], Request.Form["description"]);
            return RedirectToPage("TaskList");
        }
    }
}
