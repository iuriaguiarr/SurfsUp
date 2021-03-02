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
    public class SurfistasController : Controller
    {
        private readonly TaDandoOndaContext _context;

        public IEnumerable<object> ManobraId { get; private set; }

        public SurfistasController(TaDandoOndaContext context)
        {
            _context = context;
        }

        // GET: Surfistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Surfistas.ToListAsync());
        }

        // GET: Surfistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfista = await _context.Surfistas
                .Include(manobra=>manobra.Manobras)
                .FirstOrDefaultAsync(m => m.SurfistaId == id);
            if (surfista == null)
            {
                return NotFound();
            }
            // ViewData["ManobraId"] = new SelectList(Manobras, "ManobraId", "Nome");
            return View(surfista);
        }

        // GET: Surfistas/Create
        public IActionResult Create()
        {
            List<Manobra> Manobras = _context.Manobras.Where(p => p.Surfista == null).ToList();
            ViewData["ManobraId"] = new SelectList(Manobras, "ManobraId", "Nome");
            return View();
        }

        // POST: Surfistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurfistaId,Nome,Cidade,Estado,Idade,ManobraId")] Surfista surfista, List<int> ManobraId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surfista);
                await _context.SaveChangesAsync();
                foreach(var id in ManobraId){
                    Manobra manobra = _context.Manobras.Find(id);
                    manobra.SurfistaId = surfista.SurfistaId;
                    _context.Update(manobra);
                    await _context.SaveChangesAsync();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(surfista);
        }

        // GET: Surfistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfista = await _context.Surfistas.FindAsync(id);
            if (surfista == null)
            {
                return NotFound();
            }
            List<Manobra> Manobras = _context.Manobras.Where(p => p.Surfista == null).ToList();
            ViewData["ManobraId"] = new SelectList(Manobras, "ManobraId", "Nome");
            return View(surfista);
        }

        // POST: Surfistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurfistaId,Nome,Cidade,Estado,Idade,ManobraId")] Surfista surfista, List<int> ManobraId)
        {
            if (id != surfista.SurfistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surfista);
                    await _context.SaveChangesAsync();
                    foreach(var idd in ManobraId){
                    Manobra manobra = _context.Manobras.Find(idd);
                    manobra.SurfistaId = surfista.SurfistaId;
                    _context.Update(manobra);
                    await _context.SaveChangesAsync();

                }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurfistaExists(surfista.SurfistaId))
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
            return View(surfista);
        }

        // GET: Surfistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfista = await _context.Surfistas
                .FirstOrDefaultAsync(m => m.SurfistaId == id);
            if (surfista == null)
            {
                return NotFound();
            }

            return View(surfista);
        }

        // POST: Surfistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var surfista = await _context.Surfistas.FindAsync(id);
            _context.Surfistas.Remove(surfista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurfistaExists(int id)
        {
            return _context.Surfistas.Any(e => e.SurfistaId == id);
        }
    }
}
