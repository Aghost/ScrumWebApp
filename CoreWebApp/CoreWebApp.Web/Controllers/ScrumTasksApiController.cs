using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace CoreWebApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrumTasksApiController : ControllerBase
    {
        private readonly ScrumBoardDbContext _context;

        public ScrumTasksApiController(ScrumBoardDbContext context)
        {
            _context = context;
        }

        // GET: api/ScrumTasksApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrumTask>>> GetScrumTasks()
        {
            return await _context.ScrumTasks.ToListAsync();
        }

        // GET: api/ScrumTasksApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrumTask>> GetScrumTask(int id)
        {
            var scrumTask = await _context.ScrumTasks.FindAsync(id);

            if (scrumTask == null)
            {
                return NotFound();
            }

            return scrumTask;
        }

        // PUT: api/ScrumTasksApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrumTask(int id, ScrumTask scrumTask)
        {
            if (id != scrumTask.ScrumTaskId)
            {
                return BadRequest();
            }

            _context.Entry(scrumTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrumTaskExists(id))
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

        // POST: api/ScrumTasksApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScrumTask>> PostScrumTask(ScrumTask scrumTask)
        {
            _context.ScrumTasks.Add(scrumTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrumTask", new { id = scrumTask.ScrumTaskId }, scrumTask);
        }

        // DELETE: api/ScrumTasksApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScrumTask(int id)
        {
            var scrumTask = await _context.ScrumTasks.FindAsync(id);
            if (scrumTask == null)
            {
                return NotFound();
            }

            _context.ScrumTasks.Remove(scrumTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScrumTaskExists(int id)
        {
            return _context.ScrumTasks.Any(e => e.ScrumTaskId == id);
        }
    }
}
