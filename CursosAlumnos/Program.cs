using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CursosAlumnos.model;

namespace CursosAlumnos
{
    class Program
    {
        static void Main(string[] args)
        {



        }

        public static void ConsultaSimple()
        {
            using (var ctx = new CursosEntities1())

            {
                var data = ctx.Profesor.Where(o => o.nombre.Contains("Luis"));           // CREAR UNA CONSULTA //

                foreach (var profesor in data)
                {
                    Console.WriteLine(profesor);
                    
                }
            }
            
        }

        public static void Suma()
        {
            using (var ctx = new CursosEntities1())

                {
                var data = ctx.Curso.Average(o => o.duracion);                            // SUMA //


                    Console.WriteLine(data);
                }

        }

        public static void ObjetoDinamico()                                                // MODIFICACION DEL NOMBRE DEL OBJETO //
        { 
            using (var ctx = new CursosEntities1())                                             

            {
                var data = ctx.Profesor.Where(o => o.nombre.Contains("Luis"))
                    .Select(o => new {Denominacion = o.nombre, Antiguedad = o.edad});     //OPCION 1//

                var data2 = from o in ctx.Profesor
                    where o.nombre.Contains("Luis")
                    select new                                                            // OPCION 2 //
                    {
                        Denominacion = o.nombre,
                        Antiguedad = o.edad
                    };
                

                foreach (var profesor in data)
                {                                                                         
                    Console.WriteLine(profesor);
                }
                
            }

        }

        public static void BusquedaEnlazada()
        {
            using (var ctx = new CursosEntities1())
            {
                var curpro = ctx.CursoProfesor.Where(o => o.idProfesor == 1).Select(o => o.Curso);

                curpro = curpro.Where(o => o.inicio == DateTime.Now).OrderBy(o => o.duracion);                // CON LAZYLOADING //

                var rf = curpro.Where(o => o.Alumno.Select(oo => oo.dni).Contains("1234A").ToArray());

            }
        }

        public static void Subselect()
        {


            using (var ctx = new CursosEntities1())
            {
                var curpro = ctx.Alumno.Find(1).Curso.Select(o => o.CursoProfesor.Select(oo => oo.Profesor));
            }
        }

        public static void SinLazy()
        {


            using (var ctx = new CursosEntities1())
            {
                ctx.Configuration.LazyLoadingEnabled = false;

                var alu = ctx.Alumno.Include("Curso").
                    Where(o => o.dni.Contains("A"));         // AQUI SACO TODAS LAS "A" QUE TIENE EL NOMBRE DE UN ALUMNO //
            }
        }







    }




}
