using System;
using System.Collections.Generic;
using System.Linq;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            var Alumno = new Alumno { Nombre = "Santiago Vásquez" };
            return View(Alumno);
        }
        public IActionResult MultiAlumno()
        {
            var listaAlumno = GenerarAlumnosAlAzar(20);
            ViewBag.Fecha = DateTime.Now;
            ViewBag.CosaDinamica = "La Monja";
            return View("MultiAlumno", listaAlumno);
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
                               
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }
    }
}