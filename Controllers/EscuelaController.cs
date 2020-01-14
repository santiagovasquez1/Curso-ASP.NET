using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela("Platzi",2005);
            //Bolsa de objetos dinamicos
            //Envia informacion a las vistas
            ViewBag.CosaDinamica = "La Monja";

            return View(escuela);
        }
    }
}