using Microsoft.AspNetCore.Mvc;
using Evaluacion3.Models;

namespace Evaluacion3.Controllers
{
    public class TipoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() // Views - Marcas - Index
        {
            var Tipo = _context.tblTipos.ToList();

            CreateTipoModelsView Ctmv = new CreateTipoModelsView();
            Ctmv.Tipo = Tipo;
            return View(Ctmv);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Tipo")] Tipo T)
        {
            if (T == null) return View();

            if (ModelState.IsValid)
            {
                _context.Add(T);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(T);
        }

        [HttpGet]
        public IActionResult Edit(int IdTipo)
        {
            var Tipo = _context.tblTipos.FirstOrDefault(m => m.Id == IdTipo);
            if (Tipo == null) return NotFound();
            else
            {
                return View(Tipo);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Tipo Tipo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Tipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tipo);
        }


        [HttpGet]
        public IActionResult Delete(int IdTipo)
        {
            var Tipo = _context.tblTipos.FirstOrDefault(m => m.Id == IdTipo);
            if (Tipo == null) return NotFound();
            else
            {
                return View(Tipo);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Tipo Tipo)
        {
            _context.Remove(Tipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
