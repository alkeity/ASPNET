﻿using System.Collections.Generic;
using Homework8_TaskManagerAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework8_TaskManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
