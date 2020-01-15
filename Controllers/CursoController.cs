using System;
using System.Collections.Generic;
using System.Linq;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        [Route("Curso/Index")]
        [Route("Curso/Index/{cursoId}")]
        public IActionResult Index(string cursoId)
        {
            if (!string.IsNullOrWhiteSpace(cursoId))
            {
                var Curso = _context.Cursos.ToList().Find(x => x.Id == cursoId);
                return View(Curso);
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }

        }
        public IActionResult MultiCurso()
        {
            //var listaAlumno = GenerarAlumnosAlAzar(1500);
            ViewBag.Fecha = DateTime.Now;
            ViewBag.CosaDinamica = "La Monja";
            return View("MultiAlumno", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.Mensaje = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }

        }

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}