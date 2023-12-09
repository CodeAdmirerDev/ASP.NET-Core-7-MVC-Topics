using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningMVC.Areas.Identity.Data;
using LearningMVC.Models;

namespace LearningMVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly ExampleContext _context;

        public RolesController(ExampleContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
              return _context.LearningMVCRoles != null ? 
                          View(await _context.LearningMVCRoles.ToListAsync()) :
                          Problem("Entity set 'ExampleContext.LearningMVCRoles'  is null.");
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LearningMVCRoles == null)
            {
                return NotFound();
            }

            var learningMVCRoles = await _context.LearningMVCRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningMVCRoles == null)
            {
                return NotFound();
            }

            return View(learningMVCRoles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleDesc,Id,Name,NormalizedName,ConcurrencyStamp")] LearningMVCRoles learningMVCRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningMVCRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningMVCRoles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LearningMVCRoles == null)
            {
                return NotFound();
            }

            var learningMVCRoles = await _context.LearningMVCRoles.FindAsync(id);
            if (learningMVCRoles == null)
            {
                return NotFound();
            }
            return View(learningMVCRoles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoleDesc,Id,Name,NormalizedName,ConcurrencyStamp")] LearningMVCRoles learningMVCRoles)
        {
            if (id != learningMVCRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningMVCRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningMVCRolesExists(learningMVCRoles.Id))
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
            return View(learningMVCRoles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LearningMVCRoles == null)
            {
                return NotFound();
            }

            var learningMVCRoles = await _context.LearningMVCRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningMVCRoles == null)
            {
                return NotFound();
            }

            return View(learningMVCRoles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LearningMVCRoles == null)
            {
                return Problem("Entity set 'ExampleContext.LearningMVCRoles'  is null.");
            }
            var learningMVCRoles = await _context.LearningMVCRoles.FindAsync(id);
            if (learningMVCRoles != null)
            {
                _context.LearningMVCRoles.Remove(learningMVCRoles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningMVCRolesExists(string id)
        {
          return (_context.LearningMVCRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
