using Microsoft.AspNetCore.Mvc;
using WebCrud.Contexto;

namespace WebCrud.Controllers
{
    public class CalculadoraController : Controller
    {
       private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;   
        }

        public IActionResult Calcular()
        {
            return View();
        }
    }
}
