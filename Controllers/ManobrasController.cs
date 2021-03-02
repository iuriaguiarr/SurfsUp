using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaDandoOnda.Models;

namespace TaDandoOnda.Controllers
{
    public class ManobrasController : Controller
    {
        private readonly TaDandoOndaContext _context;

        public ManobrasController(TaDandoOndaContext context)
        {
            _context = context;
        }

        // GET: Manobras
        public async Task<IActionResult> Index()
        {
            var taDandoOndaContext = _context.Manobras.Include(m => m.Surfista);
            return View(await taDandoOndaContext.ToListAsync());
        }

        // GET: Manobras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras
                .Include(m => m.Surfista)
                .FirstOrDefaultAsync(m => m.ManobraId == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // GET: Manobras/Create
        public IActionResult Create()
        {
            ViewData["SurfistaId"] = new SelectList(_context.Surfistas, "SurfistaId", "Nome");
            return View();
        }

        // POST: Manobras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManobraId,Nome,Aérea,TipoDeOnda,SurfistaId")] Manobra manobra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manobra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SurfistaId"] = new SelectList(_context.Surfistas, "SurfistaId", "Nome", manobra.SurfistaId);
            return View(manobra);
        }

        // GET: Manobras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras.FindAsync(id);
            if (manobra == null)
            {
                return NotFound();
            }
            ViewData["SurfistaId"] = new SelectList(_context.Surfistas, "SurfistaId", "Nome", manobra.SurfistaId);
            return View(manobra);
        }

        // POST: Manobras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManobraId,Nome,Aérea,TipoDeOnda,SurfistaId")] Manobra manobra)
        {
            if (id != manobra.ManobraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manobra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManobraExists(manobra.ManobraId))
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
            ViewData["SurfistaId"] = new SelectList(_context.Surfistas, "SurfistaId", "Nome", manobra.SurfistaId);
            return View(manobra);
        }

        // GET: Manobras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras
                .Include(m => m.Surfista)
                .FirstOrDefaultAsync(m => m.ManobraId == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // POST: Manobras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manobra = await _context.Manobras.FindAsync(id);
            _context.Manobras.Remove(manobra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManobraExists(int id)
        {
            return _context.Manobras.Any(e => e.ManobraId == id);
        }
    }
}
