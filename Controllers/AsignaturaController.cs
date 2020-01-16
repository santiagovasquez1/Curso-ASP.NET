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

        [Route("Asignatura/Index/{Id}")] //Atributo antes del index
        public IActionResult Index(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                //Busqueda Linq
                var Asignatura = from asig in _context.Asignaturas
                                 where asig.Id == Id
                                 select asig;

                //Busqueda Lambda
                var prueba = _context.Asignaturas.ToList().Find(asig => asig.Id == Id);
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

        #region Crear
        public IActionResult Create()
        {
            ViewBag.Cursos = _context.Cursos.ToArray().Select(x => x.Id).ToArray();
            ViewBag.Fecha = DateTime.Now;
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.Mensaje = "Asignatura Creada";
                ViewBag.CursoNombre = _context.Cursos.ToList().Find(x => x.Id == asignatura.CursoId).Nombre;
                return View("Index", asignatura);
            }
            else
            {
                ViewBag.Cursos = _context.Cursos.ToArray().Select(x => x.Id).ToArray();
                return View(asignatura);
            }

        }
        #endregion

        #region Editar

        [Route("Asignatura/Edit/{Id}")]
        public IActionResult Edit(string Id)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                var Asignatura = _context.Asignaturas.ToList().Find(x => x.Id == Id);
                ViewBag.Cursos = _context.Cursos.ToArray().Select(x => x.Id).ToArray();
                return View("Edit", Asignatura);
            }
            else
            {
                return Content("Los datos proporcionados no son suficientes");
            }
        }

        [HttpPost]
        [Route("Asignatura/Edit/{asignaturaId}")]
        public IActionResult Edit(Asignatura asignatura, string asignaturaId)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                var cursoAsignatura = _context.Cursos.ToList().Find(x => x.Id == asignatura.CursoId);
                asignatura.Id = asignaturaId;
                asignatura.Curso = cursoAsignatura;
                _context.Asignaturas.Update(asignatura);
                _context.SaveChanges();
                ViewBag.CursoNombre = _context.Cursos.ToList().Find(x => x.Id == asignatura.CursoId).Nombre;
                return View("Index", asignatura);
            }
            else
            {
                return View("Edit", asignatura);
            }

        }

        #endregion

    }
}