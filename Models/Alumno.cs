using System.Collections.Generic;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}