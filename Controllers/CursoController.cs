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
        [Route("Curso/Index/{Id}")]
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var Curso = _context.Cursos.ToList().Find(x => x.Id == Id);
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
        #region Crear
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
        #endregion

        #region Editar
        [Route("Curso/Edit/{Id}")]
        public IActionResult Edit(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var Curso = _context.Cursos.ToList().Find(x => x.Id == Id);
                //ViewBag.Cursos = _context.Cursos.ToArray().Select(x => x.Id).ToArray();
                return View("Edit", Curso);
            }
            else
            {
                return Content("Los datos proporcionados no son suficientes");
            }
        }

        [HttpPost]
        [Route("Curso/Edit/{cursoId}")]
        public IActionResult Edit(Curso curso, string cursoId)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                curso.Id = cursoId;
                _context.Cursos.Update(curso);
                _context.SaveChanges();
                return View("Index", curso);
            }
            else
            {
                return View("Edit", curso);
            }

        }

        #endregion
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}