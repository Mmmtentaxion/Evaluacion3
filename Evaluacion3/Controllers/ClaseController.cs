using Microsoft.AspNetCore.Mvc;
using Evaluacion3.Models;

namespace Evaluacion3.Controllers
{
    public class ClaseController : Controller
    {
        private readonly AppDbContext _context;

        public ClaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() // Views - Marcas - Index
        {
            var Clase = _context.tblclases.ToList();
            return View(Clase);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Clase C)
        {
            if (C == null) return View();

            if (ModelState.IsValid)
            {
                _context.Add(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(C);
        }

        [HttpGet]
        public IActionResult Edit(int IdClase)
        {
            var Clase = _context.tblclases.FirstOrDefault(c => c.Id == IdClase);
            if (Clase == null) return NotFound();
            else
            {
                return View(Clase);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Clase Clase)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Clase);
        }


        [HttpGet]
        public IActionResult Delete(int IdClase)
        {
            var Clase = _context.tblclases.FirstOrDefault(m => m.Id == IdClase);
            if (Clase == null) return NotFound();
            else
            {
                return View(Clase);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Clase Clase)
        {
            _context.Remove(Clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}