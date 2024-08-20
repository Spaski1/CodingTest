using TaskManagerApp.Models.Enums;

namespace TaskManagerApp.Models.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
