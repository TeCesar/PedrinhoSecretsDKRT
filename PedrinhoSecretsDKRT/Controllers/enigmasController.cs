using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedrinhoSecretsDKRT.Models;

namespace PedrinhoSecretsDKRT.Controllers
{
    public class enigmasController : Controller
    {
        private readonly PedrinhoSecretsDKRTContext _context;

        public enigmasController(PedrinhoSecretsDKRTContext context)
        {
            _context = context;
        }

        // GET: enigmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.enigmas.ToListAsync());
        }

        // GET: enigmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enigmas = await _context.enigmas
                .FirstOrDefaultAsync(m => m.id == id);
            if (enigmas == null)
            {
                return NotFound();
            }

            return View(enigmas);
        }

        // GET: enigmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: enigmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,resposta")] enigmas enigmas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enigmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enigmas);
        }

        // GET: enigmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enigmas = await _context.enigmas.FindAsync(id);
            if (enigmas == null)
            {
                return NotFound();
            }
            return View(enigmas);
        }

        // POST: enigmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,resposta")] enigmas enigmas)
        {
            if (id != enigmas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enigmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!enigmasExists(enigmas.id))
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
            return View(enigmas);
        }

        // GET: enigmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enigmas = await _context.enigmas
                .FirstOrDefaultAsync(m => m.id == id);
            if (enigmas == null)
            {
                return NotFound();
            }

            return View(enigmas);
        }

        // POST: enigmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enigmas = await _context.enigmas.FindAsync(id);
            _context.enigmas.Remove(enigmas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool enigmasExists(int id)
        {
            return _context.enigmas.Any(e => e.id == id);
        }
    }
}
