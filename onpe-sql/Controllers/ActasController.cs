using Microsoft.AspNetCore.Mvc;

namespace onpe_sql.Controllers
{
    public class ActasController : Controller
    {
        public IActionResult verActasUbigeo()
        {
            return View();
        }

        public IActionResult verActa()
        {
            return View();
        }
    }
}
