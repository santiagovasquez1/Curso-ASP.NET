using System;
using System.Collections.Generic;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var Asignatura = new Asignatura { Nombre = "Fundamentos de Programación" };
            return View(Asignatura);
        }
        public IActionResult MultiAsignatura()
        {
            var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas", Descripicion="La matemática en realidad es un conjunto de lenguajes formales que pueden ser usados como herramienta para plantear problemas de manera no ambigua en contextos específicos. Por ejemplo, el siguiente enunciado podemos decirlo de dos formas: X es mayor que Y e Y es mayor que Z, o forma simplificada podemos decir que X > Y > Z. Este es el motivo por el cual las matemáticas son tan solo un lenguaje simplificado con una herramienta para cada problema específico (por ejemplo 2+2= 4, o 2x2= 4)."} ,
                            new Asignatura{Nombre="Educación Física" ,Descripicion="ormación destinada a desarrollar la capacidad intelectual, moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la sociedad a la que pertenecen."},
                            new Asignatura{Nombre="Castellano", Descripicion="desarrollo de la competencia comunicativa de los escolares, es decir, que aprendan a utilizar el lenguaje hablado y escrito para comunicarse de manera afectiva en distintas situaciones. Para lograr este fin es necesario que los escolares desarrollen las habilidades de Hablar, Escuchar, Leer y Comprender."},
                            new Asignatura{Nombre="Ciencias Naturales", Descripicion="Las ciencias naturales, ciencias de la naturaleza, ciencias físico-naturales o ciencias experimentales son aquellas ciencias que tienen por objeto el estudio de la naturaleza, siguiendo la modalidad del método científico conocida como método experimental. Estudian los aspectos físicos e intentando no incluir aspectos relativos a las acciones humanas. Así, como grupo, las ciencias naturales se distinguen de las ciencias sociales o ciencias humanas (cuya identificación o diferenciación de las humanidades y artes y de otro tipo de saberes es un problema epistemológico diferente)."},
                            new Asignatura {Nombre = "Fundamentos de Programación",Descripicion="Fundamentos de Programación es una asignatura básica que permite crear programas que exhiban un comportamiento deseado. El proceso de escribir código requiere frecuentemente conocimientos en varias áreas distintas, además del dominio del lenguaje a utilizar, algoritmos especializados y lógica formal."}
                };

            ViewBag.Fecha = DateTime.Now;
            ViewBag.CosaDinamica = "La Monja";
            return View("MultiAsignatura", listaAsignaturas);
        }
    }
}