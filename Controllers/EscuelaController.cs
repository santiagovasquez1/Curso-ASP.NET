using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class EscuelaController : Controller
    {

        private EscuelaContext _context;
        public IActionResult Index()
        { 
            var escuela=_context.Escuelas.FirstOrDefault();            
            return View(escuela);
        }

        public EscuelaController(EscuelaContext Context)
        {
            _context = Context;
        }
    }
}