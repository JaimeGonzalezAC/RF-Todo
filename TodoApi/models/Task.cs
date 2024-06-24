using System;

namespace TodoApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        public bool IsImportant { get; set; }

        // Foreign key for Goal
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}
