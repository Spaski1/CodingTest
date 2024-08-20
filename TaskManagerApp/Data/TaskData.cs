using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TaskManagerApp.Models.Entities;
using TaskManagerApp.Models.Enums;


namespace TaskManagerApp.Data
{
    public class TaskData: DbContext
    {
        public TaskData(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity { Id = 1, Name = "Task 1", DueDate = DateTime.Now.AddDays(1), Status = Status.NotStarted },
                new TaskEntity { Id = 2, Name = "Task 2", DueDate = DateTime.Now.AddDays(2), Status = Status.InProgress },
                new TaskEntity { Id = 3, Name = "Task 3", DueDate = DateTime.Now.AddDays(3), Status = Status.Completed },
                new TaskEntity { Id = 4, Name = "Task 4", DueDate = DateTime.Now.AddDays(4), Status = Status.OnHold },
                new TaskEntity { Id = 5, Name = "Task 5", DueDate = DateTime.Now.AddDays(5), Status = Status.NotStarted },
                new TaskEntity { Id = 6, Name = "Task 6", DueDate = DateTime.Now.AddDays(6), Status = Status.InProgress },
                new TaskEntity { Id = 7, Name = "Task 7", DueDate = DateTime.Now.AddDays(7), Status = Status.Completed },
                new TaskEntity { Id = 8, Name = "Task 8", DueDate = DateTime.Now.AddDays(8), Status = Status.OnHold },
                new TaskEntity { Id = 9, Name = "Task 9", DueDate = DateTime.Now.AddDays(9), Status = Status.NotStarted },
                new TaskEntity { Id = 10, Name = "Task 10", DueDate = DateTime.Now.AddDays(10), Status = Status.Completed }
            );
        }
    }
}
