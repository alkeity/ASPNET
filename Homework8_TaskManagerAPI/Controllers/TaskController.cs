using Homework8_TaskManagerAPI.Data.Models;
using Homework8_TaskManagerAPI.Models.DTO;
using Homework8_TaskManagerAPI.Models.Responce;
using Homework8_TaskManagerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Homework8_TaskManagerAPI.Controllers
{
    [Route("v1/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<List<TaskItem>> GetTasks()
        {
            return _taskService.GetTaskItems();
        }

        [HttpGet]
        [Route("{id:long}")]
        public ActionResult<TaskDTO> GetTask([FromRoute] long id)
        {
            try
            {
                TaskItem? item = _taskService.GetTaskItem(id);
                if (item == null) return NotFound();
                return new TaskDTO() { Title = item.Title, Description = item.Description, IsDone = item.IsDone, CreatedAt = item.CreatedAt };
            }
            catch (Exception) // stub
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Add")]
        public IActionResult CreateTask([FromForm] TaskDTO task)
        {
            try
            {
                long id = _taskService.AddTask(task);
                return CreatedAtAction(nameof(GetTask), new { id }, task);
            }
            catch (Exception) // stub
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            try
            {
                TaskItem? item = _taskService.GetTaskItem(id);
                if (item == null) return NotFound();
                _taskService.DeleteTask(id);
                return NoContent();
            }
            catch (Exception) // stub
            {
                throw;
            }
        }
    }
}
