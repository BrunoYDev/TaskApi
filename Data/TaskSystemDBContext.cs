using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data.Map;
using TaskApi.Models;

namespace TaskApi.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}