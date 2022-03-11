using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebCrud.Contexto;
using WebCrud.Models;

namespace WebCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebCrudContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, WebCrudContext context)
        {
            _logger = logger;
            _context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //CRUD actions
        public async Task<IActionResult> Index(string nome)
        {
            var formulario = from m in _context.Formulario
                             select m;

            var webCrudViewModel = new Models.WebCrudViewModels
            {
                Formulario = await formulario.ToListAsync()
            };

            return View(webCrudViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,SobreNome,Telefone,Email,DataNascimento,Cpf,Rg")]Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));   
            }
            return View(formulario);
        }

        //GET DELETE        
        public async Task<IActionResult> Delete(int id)
        {
            if(id == null)
            {
                return NotFound();  
            }

            var formulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.Id == id);

            if(formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        //POST DELETE

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formulario.FindAsync(id);
            _context.Formulario.Remove(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get edit
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario.FindAsync(id);
            if(formulario == null)
            {
                return NotFound();
            }
            return View(formulario);
        }

        //Post edit

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,SobreNome,Telefone,Email,DataNascimento,Cpf,Rg")]Formulario formulario)
        {
            if(id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulario);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!FormularioExists(formulario.Id))
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
            return View(formulario);
        }

        private bool FormularioExists(int id)
        {
            return _context.Formulario.Any(e => e.Id == id);    
        }

        //Get detalher
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.Id == id);
                

            if(formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }
    }

}