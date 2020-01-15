using System;

namespace Curso_de_ASP.NET_Core.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get;  set; }
        public string Nombre { get; set; }

        public string Descripicion { get; set; } = "";

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}