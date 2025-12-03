using Microsoft.AspNetCore.Mvc;

namespace BibliotecaNacional.Controllers
{
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View(); 
        }
    }
}