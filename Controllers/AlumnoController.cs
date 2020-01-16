using System;
using System.Collections.Generic;
using System.Linq;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{Id}")]
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var Alumno = _context.Alumnos.ToList().Find(x => x.Id == Id);
                ViewBag.CursoNombre = _context.Cursos.ToList().Find(x => x.Id == Alumno.CursoId).Nombre;
                return View(Alumno);
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }

        }
        public IActionResult MultiAlumno()
        {
            //var listaAlumno = GenerarAlumnosAlAzar(1500);
            ViewBag.Fecha = DateTime.Now;
            ViewBag.CosaDinamica = "La Monja";
            return View("MultiAlumno", _context.Alumnos);
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

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        #region Crear
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                ViewBag.Mensaje = "Alumno Creado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }

        }
        #endregion

        #region  Editar
        [Route("Alumno/Edit/{Id}")]
        public IActionResult Edit(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var Alumno = _context.Alumnos.ToList().Find(x => x.Id == Id);                 
                ViewBag.Cursos = _context.Cursos.ToArray().Select(x => x.Id).ToArray();
                return View("Edit", Alumno);
            }
            else
            {
                return Content("Los datos proporcionados no son suficientes");
            }
        }

        [HttpPost]
        [Route("Alumno/Edit/{alumnoId}")]
        public IActionResult Edit(Alumno alumno, string alumnoId)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {                
                var cursoAlumno = _context.Cursos.ToList().Find(x => x.Id == alumno.CursoId);
                alumno.Id = alumnoId;
                alumno.Curso = cursoAlumno;
                _context.Alumnos.Update(alumno);
                _context.SaveChanges();
                ViewBag.CursoNombre = _context.Cursos.ToList().Find(x => x.Id == alumno.CursoId).Nombre;
                return View("Index", alumno);
            }
            else
            {
                return View("Edit", alumno);
            }

        }
        #endregion

        #region Eliminar
        public IActionResult Eliminar(string alumnoId)
        {
            if (!string.IsNullOrWhiteSpace(alumnoId))
            {
                var Alumno = _context.Alumnos.ToList().Find(x => x.Id == alumnoId);
                _context.Alumnos.Remove(Alumno);
                _context.SaveChanges();
                return View("MultiAlumno", _context.Alumnos);
            }
            else
            {
                return Content("Los datos proporcionados no son suficientes");
            }

        }


        #endregion

        private Alumno GetAlumno(string pAlumnoId)
        {

            var alumnosResults = from alumno in _context.Alumnos
                                 where alumno.Id == pAlumnoId
                                 select alumno;

            return alumnosResults.SingleOrDefault();
        }

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}