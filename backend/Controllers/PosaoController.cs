using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class PosaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
