using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Asignatura : ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get; set; }        
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        [Required]
        public override string Descripicion { get; set; }
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