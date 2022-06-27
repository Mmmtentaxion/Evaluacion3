using Microsoft.AspNetCore.Mvc;
using Evaluacion3.Models;

namespace Evaluacion3.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() // Views - Marcas - Index
        {
            var Categoria = _context.tblCategorias.ToList();
            return View(Categoria);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Categoria C)
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
        public IActionResult Edit(int IdCategoria)
        {
            var C = _context.tblCategorias.FirstOrDefault(m => m.Id == IdCategoria);
            if (C == null) return NotFound();
            else
            {
                return View(C);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Update(C);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(C);
        }


        [HttpGet]
        public IActionResult Delete(int IdCategoria)
        {
            var C = _context.tblCategorias.FirstOrDefault(m => m.Id == IdCategoria);
            if (C == null) return NotFound();
            else
            {
                return View(C);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Categoria C)
        {
            _context.Remove(C);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
