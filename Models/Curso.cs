using System;
using System.Collections.Generic;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }
    }
}