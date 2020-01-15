using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}