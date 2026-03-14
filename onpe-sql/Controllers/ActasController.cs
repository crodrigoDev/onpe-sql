using Microsoft.AspNetCore.Mvc;
using onpe_sql.Controllers.dao;
using onpe_sql.Models;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace onpe_sql.Controllers
{
    public class ActasController : Controller
    {
        private readonly daoUbigeo _dao;
        private readonly daoActas _daoA;
        public ActasController(daoUbigeo dao, daoActas daoA)
        {
            _dao = dao;
            _daoA = daoA;
        }
        public IActionResult verActasUbigeo()
        {
            return View();
        }

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

        public JsonResult verDistritos(int id)
        {
            var lista = _dao.getDistritos(id);
            return Json(lista);
        }
        public JsonResult verLocales(int id)
        {
            var lista = _dao.getLocales(id);
            return Json(lista);
        }

        public IActionResult _GruposVotacion(int id)
        {
            var lista = _daoA.getGrupos(id);
            return PartialView("_GruposVotacion",lista);
        }

        public IActionResult _ActaDetalle(string id)
        {
            var lista = _daoA.getDetalle(id);
            ViewBag.Estado = (lista.idEstado == 1 ? "ACTA ELECTORAL NORMAL" : "ACTA ELECTORAL RESUELTA");
            ViewBag.TotalVotos = lista.VB + lista.VI + lista.VN;
            return PartialView("_ActaDetalle", lista);
        }
        public IActionResult verActasNumero()
        {
            return View();
        }
    }
}
