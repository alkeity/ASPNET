using System.ComponentModel.DataAnnotations;
using App_ToDoList.Models;
using App_ToDoList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_ToDoList.Pages.Tasks
{
    public class TaskEditModel : PageModel
    {
        private readonly ITaskService _taskService;

        [BindProperty(SupportsGet = true)]
        public long? Id { get; set; }

        [BindProperty]
        [Required]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public required string Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public TaskEditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public void OnGet()
        {
            if (Id != null)
            {
                TaskItem item = _taskService.GetTaskById((ulong)Id);
                Title = item.Name;
                Description = item.Description;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Id == null) _taskService.CreateTask(Title, Description);
            else _taskService.EditTask((ulong)Id, Title, Description);
            return RedirectToPage("TaskList");
        }

        public IActionResult OnGetDelete()
        {
            // TODO confirmation
            _taskService.DeleteTask((ulong)Id);
            return RedirectToPage("TaskList");
        }
    }
}
