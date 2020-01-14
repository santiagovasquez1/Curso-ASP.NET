namespace Curso_de_ASP.NET_Core.Models
{
    public class AlumnoPromedio
    {
        public float alumnopromedio { get; set; }
        public string alumnoId { get; set; }
        public string alumnoNombre { get; set; }

        public override string ToString()
        {
            return $"{alumnoNombre},{alumnopromedio}";
        }
    }
}