namespace Homework8_TaskManagerAPI.Models.DTO
{
    public class TaskDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
