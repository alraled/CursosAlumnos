//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursosAlumnos.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CursoProfesor
    {
        public int idCurso { get; set; }
        public int idProfesor { get; set; }
        public string horas { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}