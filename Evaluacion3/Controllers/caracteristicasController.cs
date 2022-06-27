using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluacion3.Models;
using Evaluacion3.ModelsView;

namespace Evaluacion3.Controllers
{
    public class caracteristicasController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public caracteristicasController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
   

        public IActionResult CrearEquipo()
        {
            ViewData["Marcas"] = new SelectList(_context.tblmarcas.ToList(), "Id", "Name");
            ViewData["Tipos"] = new SelectList(_context.tblTipos.ToList(), "Id", "Name");
            ViewData["Categorias"] = new SelectList(_context.tblCategorias.ToList(), "Id", "Name");
            ViewData["Clase"] = new SelectList(_context.tblclases.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCaracteristica(caracteristicas C)
        {
            if (ModelState.IsValid)
            {
                if (C.ImagenFile == null) C.ImagenUrl = "no-disponible.png";
                else
                {
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(C.ImagenFile.FileName);
                    string extension = Path.GetExtension(C.ImagenFile.FileName);
                    C.ImagenUrl = fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension; //foto08062022131545.png 

                    string path = Path.Combine(wwwRootPath + "/img/" + C.ImagenUrl);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await C.ImagenFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(C);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(C);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var C = _context.tblcaracteristicas.Find(Id);
            if (C == null) return NotFound();
            _context.Remove(C);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int Id)
        {
            var C = await _context.tblcaracteristicas.FindAsync(Id);
            if (C == null) return NotFound();
            return View(C);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(caracteristicas C)
        {
            if (ModelState.IsValid)
            {
                if (C.ImagenFile == null) C.ImagenUrl = "no-disponible.png";
                else
                {
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(C.ImagenFile.FileName);
                    string extension = Path.GetExtension(C.ImagenFile.FileName);
                    C.ImagenUrl = fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension; //foto08062022131545.png 

                    string path = Path.Combine(wwwRootPath + "/img/" + C.ImagenUrl);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await C.ImagenFile.CopyToAsync(fileStream);
                    }
                }
                _context.Update(C);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(C);
        }




    }
}