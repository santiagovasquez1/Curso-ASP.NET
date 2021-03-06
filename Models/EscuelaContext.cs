using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Curso_de_ASP.NET_Core.Models
{
    //Maneja la conexiones a bases de datos
    public class EscuelaContext : DbContext
    {
        //Fuente de datos en forma de listas
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Avd Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            #region Creacion de bases de datos



            //Cargar cursos escuela
            var cursos = CargarCursos(escuela);

            //X cada curso cargar asignatura
            var Asignaturas = CargarAsignaturaPorCurso(cursos);

            //X cada curso cargar alumnos
            var Alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(Asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(Alumnos.ToArray());

            // modelBuilder.Entity<Asignatura>().HasData(new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid().ToString(), Descripicion = "La matemática en realidad es un conjunto de lenguajes formales que pueden ser usados como herramienta para plantear problemas de manera no ambigua en contextos específicos. Por ejemplo, el siguiente enunciado podemos decirlo de dos formas: X es mayor que Y e Y es mayor que Z, o forma simplificada podemos decir que X > Y > Z. Este es el motivo por el cual las matemáticas son tan solo un lenguaje simplificado con una herramienta para cada problema específico (por ejemplo 2+2= 4, o 2x2= 4)." },
            //                 new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid().ToString(), Descripicion = "ormación destinada a desarrollar la capacidad intelectual, moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la sociedad a la que pertenecen." },
            //                 new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid().ToString(), Descripicion = "desarrollo de la competencia comunicativa de los escolares, es decir, que aprendan a utilizar el lenguaje hablado y escrito para comunicarse de manera afectiva en distintas situaciones. Para lograr este fin es necesario que los escolares desarrollen las habilidades de Hablar, Escuchar, Leer y Comprender." },
            //                 new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString(), Descripicion = "Las ciencias naturales, ciencias de la naturaleza, ciencias físico-naturales o ciencias experimentales son aquellas ciencias que tienen por objeto el estudio de la naturaleza, siguiendo la modalidad del método científico conocida como método experimental. Estudian los aspectos físicos e intentando no incluir aspectos relativos a las acciones humanas. Así, como grupo, las ciencias naturales se distinguen de las ciencias sociales o ciencias humanas (cuya identificación o diferenciación de las humanidades y artes y de otro tipo de saberes es un problema epistemológico diferente)." },
            //                 new Asignatura { Nombre = "Fundamentos de Programación", Id = Guid.NewGuid().ToString(), Descripicion = "Fundamentos de Programación es una asignatura básica que permite crear programas que exhiban un comportamiento deseado. El proceso de escribir código requiere frecuentemente conocimientos en varias áreas distintas, además del dominio del lenguaje a utilizar, algoritmos especializados y lógica formal." });

            //modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar(20).ToArray());

            #endregion
        }

        private static List<Alumno> GenerarAlumnosAlAzar(int cantidad, Curso curso)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { CursoId = curso.Id, Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            var escCursos = new List<Curso>(){
                        new Curso(){ Nombre = "101",Direccion="Avenida siempre viva", Jornada = TiposJornada.Mañana ,EscuelaId=escuela.Id,Id=Guid.NewGuid().ToString()},
                        new Curso() {Nombre = "201",Direccion="Avenida siempre viva", Jornada = TiposJornada.Mañana,EscuelaId=escuela.Id,Id=Guid.NewGuid().ToString()},
                        new Curso{Nombre = "301",Direccion="Avenida siempre viva", Jornada = TiposJornada.Mañana,EscuelaId=escuela.Id,Id=Guid.NewGuid().ToString()},
                        new Curso(){ Nombre = "401",Direccion="Avenida siempre viva", Jornada = TiposJornada.Tarde,EscuelaId=escuela.Id,Id=Guid.NewGuid().ToString() },
                        new Curso() {Nombre = "501",Direccion="Avenida siempre viva", Jornada = TiposJornada.Tarde,EscuelaId=escuela.Id,Id=Guid.NewGuid().ToString()},
            };

            // Random rnd = new Random();
            // foreach (var c in escCursos)
            // {
            //     int cantRandom = rnd.Next(5, 20);
            //     c.Alumnos = GenerarAlumnosAlAzar(cantRandom, c);
            // }

            return escCursos;
        }

        private static List<Asignatura> CargarAsignaturaPorCurso(List<Curso> cursos)
        {

            List<Asignatura> ListaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura>{new Asignatura { Nombre = "Matemáticas", Id = Guid.NewGuid().ToString(), Descripicion = "La matemática en realidad es un conjunto de lenguajes formales que pueden ser usados como herramienta para plantear problemas de manera no ambigua en contextos específicos. Por ejemplo, el siguiente enunciado podemos decirlo de dos formas: X es mayor que Y e Y es mayor que Z, o forma simplificada podemos decir que X > Y > Z. Este es el motivo por el cual las matemáticas son tan solo un lenguaje simplificado con una herramienta para cada problema específico (por ejemplo 2+2= 4, o 2x2= 4)." },
                            new Asignatura { Nombre = "Educación Física", Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Descripicion = "ormación destinada a desarrollar la capacidad intelectual, moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la sociedad a la que pertenecen." },
                            new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Descripicion = "desarrollo de la competencia comunicativa de los escolares, es decir, que aprendan a utilizar el lenguaje hablado y escrito para comunicarse de manera afectiva en distintas situaciones. Para lograr este fin es necesario que los escolares desarrollen las habilidades de Hablar, Escuchar, Leer y Comprender." },
                            new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Descripicion = "Las ciencias naturales, ciencias de la naturaleza, ciencias físico-naturales o ciencias experimentales son aquellas ciencias que tienen por objeto el estudio de la naturaleza, siguiendo la modalidad del método científico conocida como método experimental. Estudian los aspectos físicos e intentando no incluir aspectos relativos a las acciones humanas. Así, como grupo, las ciencias naturales se distinguen de las ciencias sociales o ciencias humanas (cuya identificación o diferenciación de las humanidades y artes y de otro tipo de saberes es un problema epistemológico diferente)." },
                            new Asignatura { Nombre = "Fundamentos de Programación", Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Descripicion = "Fundamentos de Programación es una asignatura básica que permite crear programas que exhiban un comportamiento deseado. El proceso de escribir código requiere frecuentemente conocimientos en varias áreas distintas, además del dominio del lenguaje a utilizar, algoritmos especializados y lógica formal." }};
                ListaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }
            return ListaCompleta;
        }

        private static List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();
            Random random = new Random();

            foreach (var c in cursos)
            {
                int cantRandom = random.Next(5, 20);
                var tmpList = GenerarAlumnosAlAzar(cantRandom, c);
                listaAlumnos.AddRange(tmpList);
            }
            return listaAlumnos;
        }
    }
}