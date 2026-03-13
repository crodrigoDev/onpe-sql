using Microsoft.AspNetCore.Mvc;
using onpe_sql.Controllers.dao;
using onpe_sql.Models;

namespace onpe_sql.Controllers
{
    public class ParticipacionController : Controller
    {
        private readonly daoParticipacion _dao;

        public ParticipacionController(daoParticipacion dao)
        {
            _dao = dao;
        }
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult verParticipacion()
        {
            return View();
        }

        public IActionResult Participacion(int inicio, int fin, string ambito)
        {
            var lista = _dao.getVerParticipaciones(inicio, fin);

            ViewBag.Ambito = ambito;
            ViewBag.TituloColumna = (ambito == "NACIONAL") ? "DEPARTAMENTO" : "CONTINENTE";
            ViewBag.Accion = "verProvincia";

            return View("Participacion", lista);
        }

        public IActionResult verProvincia(string detalle, string ambito)
        {
            var lista = _dao.getVerDepartamento(detalle);

            ViewBag.Ambito = ambito;
            ViewBag.DatoNivel1 = detalle;
            ViewBag.EtiquetaNivel1 = (ambito == "NACIONAL") ? "Departamento" : "Continente";
            ViewBag.TituloColumna = (ambito == "NACIONAL") ? "PROVINCIA" : "PAÍS";
            ViewBag.Accion = "verDistrito";

            return View("Participacion", lista);
        }
        public IActionResult verDistrito(string detalle, string ambito, string nivel1Anterior)
        {
            var lista = _dao.getVerProvincia(detalle);

            ViewBag.Ambito = ambito;
            ViewBag.DatoNivel1 = nivel1Anterior;
            ViewBag.DatoNivel2 = detalle;
            ViewBag.EtiquetaNivel1 = (ambito == "NACIONAL") ? "Departamento" : "Continente";
            ViewBag.EtiquetaNivel2 = (ambito == "NACIONAL") ? "Provincia" : "País";
            ViewBag.TituloColumna = (ambito == "NACIONAL") ? "DISTRITO" : "CIUDAD";
            ViewBag.Accion= "verProvincia";

            return View("Participacion", lista);
        }

    }
}
