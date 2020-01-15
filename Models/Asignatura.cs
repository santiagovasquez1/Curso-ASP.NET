using System;
using System.Collections.Generic;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Asignatura : ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }

        // public override bool Equals(object obj)
        // {
        //     if (obj is Asignatura)
        //     {
        //         Asignatura temp = (Asignatura)obj;
        //         if (Nombre == temp.Nombre) return true;
        //     }
        //     return false;

        // }
    }

}