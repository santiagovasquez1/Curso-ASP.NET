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
            // var escuela = new Escuela("Platzi School", 2005);
            // escuela.Direccion = "Cra63C #42B-11";
            // escuela.Ciudad = "Medellín";
            // escuela.Pais = "Colombia";
            // escuela.TipoEscuela = TiposEscuela.Secundaria;
            //Bolsa de objetos dinamicos
            //Envia informacion a las vistas
            //ViewBag.CosaDinamica = "La Monja";

            var escuela=_context.Escuelas.FirstOrDefault();            
            return View(escuela);
        }

        public EscuelaController(EscuelaContext Context)
        {
            _context = Context;
        }
    }
}