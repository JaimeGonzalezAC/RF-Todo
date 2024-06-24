using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Task = TodoApi.Models.Task;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar las relaciones y restricciones
            modelBuilder.Entity<Goal>()
                .HasMany(g => g.Tasks)
                .WithOne(t => t.Goal)
                .HasForeignKey(t => t.GoalId);
        }
    }
}
