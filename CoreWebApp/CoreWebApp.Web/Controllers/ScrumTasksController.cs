using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace CoreWebApp.Web.Controllers
{
    public class ScrumTasksController : Controller
    {
        private readonly ScrumBoardDbContext _context;

        public ScrumTasksController(ScrumBoardDbContext context)
        {
            _context = context;
        }

        // GET: ScrumTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScrumTasks.ToListAsync());
        }

        // GET: ScrumTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scrumTask = await _context.ScrumTasks
                .FirstOrDefaultAsync(m => m.ScrumTaskId == id);
            if (scrumTask == null)
            {
                return NotFound();
            }

            return View(scrumTask);
        }

        // GET: ScrumTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScrumTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScrumTaskId,TaskName,Status,TaskDescription,CreatedOn,UpdatedOn")] ScrumTask scrumTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scrumTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scrumTask);
        }

        // GET: ScrumTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scrumTask = await _context.ScrumTasks.FindAsync(id);
            if (scrumTask == null)
            {
                return NotFound();
            }
            return View(scrumTask);
        }

        // POST: ScrumTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScrumTaskId,TaskName,Status,TaskDescription,CreatedOn,UpdatedOn")] ScrumTask scrumTask)
        {
            if (id != scrumTask.ScrumTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scrumTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScrumTaskExists(scrumTask.ScrumTaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(scrumTask);
        }

        // GET: ScrumTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scrumTask = await _context.ScrumTasks
                .FirstOrDefaultAsync(m => m.ScrumTaskId == id);
            if (scrumTask == null)
            {
                return NotFound();
            }

            return View(scrumTask);
        }

        // POST: ScrumTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scrumTask = await _context.ScrumTasks.FindAsync(id);
            _context.ScrumTasks.Remove(scrumTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScrumTaskExists(int id)
        {
            return _context.ScrumTasks.Any(e => e.ScrumTaskId == id);
        }
    }
}
