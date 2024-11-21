using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace task_api.Models
{
    public class TaskContext:IdentityDbContext<User,Role,int>
    {
        public TaskContext(DbContextOptions<TaskContext> options):base (options)
        {}

        public DbSet<Task> Tasks { get; set; }
    }
}