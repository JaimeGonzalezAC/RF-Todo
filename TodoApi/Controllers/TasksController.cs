using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TodoContext _context;

        public TasksController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<Models.Task>> PostTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
