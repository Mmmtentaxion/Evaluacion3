using Microsoft.AspNetCore.Mvc;
using Evaluacion3.Models;

namespace Evaluacion3.Controllers
{
    public class marcaController : Controller
    {
        private readonly AppDbContext _context;

        public marcaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() // Views - Marcas - Index
        {
            var marca = _context.tblmarcas.ToList();
            return View(marca);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(marca M)
        {
            if (M == null) return View();

            if (ModelState.IsValid)
            {
                _context.Add(M);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(M);
        }

        [HttpGet]
        public IActionResult Edit(int Idmarca)
        {
            var marca = _context.tblmarcas.FirstOrDefault(m => m.Id == Idmarca);
            if (marca == null) return NotFound();
            else
            {
                return View(marca);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }


        [HttpGet]
        public IActionResult Delete(int Idmarca)
        {
            var marca = _context.tblmarcas.FirstOrDefault(m => m.Id == Idmarca);
            if (marca == null) return NotFound();
            else
            {
                return View(marca);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(marca marca)
        {
            _context.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}