using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(5)]
        public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Display(Prompt = "Dirección de correspondencia", Name = "Dirección")]
        [Required(ErrorMessage = "Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage = "La longitud minima es de 10 caracteres")]
        public string Direccion { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }

    }
}