﻿namespace App_ToDoList.Models
{
    public class TaskItem
    {
        public required ulong Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
