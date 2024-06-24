namespace TodoClient.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}
