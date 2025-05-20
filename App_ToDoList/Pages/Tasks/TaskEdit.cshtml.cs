using App_ToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_ToDoList.Pages.Tasks
{
    public class TaskEditModel : PageModel
    {
        private readonly ITaskService _taskService;

        [BindProperty]
        public required string Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public TaskEditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _taskService.CreateTask(Title, Description);
            return RedirectToPage("TaskList");
        }
    }
}
