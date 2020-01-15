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

        public IActionResult Index()
        {
            //var Asignatura = new Asignatura { Nombre = "Fundamentos de Programación" };
            return View(_context.Asignaturas.FirstOrDefault());
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