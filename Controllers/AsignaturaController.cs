using System;
using System.Linq;
using System.Collections.Generic;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        [Route("Asignatura/Index")] //Atributo antes del index

        [Route("Asignatura/Index/{asignaturaId}")] //Atributo antes del index
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                //Busqueda Linq
                var Asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignaturaId
                                 select asig;

                //Busqueda Lambda
                var prueba = _context.Asignaturas.ToList().Find(asig => asig.Id == asignaturaId);
                return View(prueba);
            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas);
            }
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.Fecha = DateTime.Now;
            ViewBag.CosaDinamica = "La Monja";
            return View("MultiAsignatura", _context.Asignaturas);
        }

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

    }
}