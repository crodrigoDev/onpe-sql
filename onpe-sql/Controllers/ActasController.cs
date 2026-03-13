using Microsoft.AspNetCore.Mvc;

namespace onpe_sql.Controllers
{
    public class ActasController : Controller
    {
        public IActionResult verActas()
        {

            return View("Participacion");
        }

        public IActionResult verActa()
        {
            return View();
        }
    }
}
