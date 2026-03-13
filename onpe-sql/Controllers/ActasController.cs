using Microsoft.AspNetCore.Mvc;
using onpe_sql.Controllers.dao;

namespace onpe_sql.Controllers
{
    public class ActasController : Controller
    {
        private readonly daoUbigeo _dao;
        public ActasController(daoUbigeo dao)
        {
            _dao = dao;
        }
        public IActionResult verActasUbigeo()
        {
            return View();
        }

        [HttpGet]
        public JsonResult verDepartamentos(string ambito)
        {
            var inicio = ambito == "P" ? 1 : 26;
            var fin = ambito == "P" ? 25 : 30;
            var lista = _dao.getDepartamentos(inicio, fin);
            return Json(lista);
        }

        public JsonResult verProvincias(int id)
        {
            var lista = _dao.getProvincias(id);
            return Json(lista);
        }

        public IActionResult verDistritos(int id)
        {
            var lista = _dao.getDistritos(id);
            return Json(lista);
        }
        public IActionResult verLocales(int id)
        {
            var lista = _dao.getLocales(id);
            return Json(lista);
        }
    }
}
