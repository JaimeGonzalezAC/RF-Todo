using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

        // Calculated properties
        public int TotalTasks => Tasks.Count;
        public int CompletedTasks => Tasks.Count(t => t.IsCompleted);
        public double CompletionPercentage => TotalTasks == 0 ? 0 : (double)CompletedTasks / TotalTasks * 100;
    }
}
