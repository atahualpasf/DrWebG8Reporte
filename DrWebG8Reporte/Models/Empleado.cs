using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Empleado : Persona
    {
        public string rol { get; set; }
        public double Sueldo { get; set; }

        public virtual ICollection<Especialidad> Especialidades { get; set; }
        public virtual ICollection<Centro> Centros { get; set; }
    }
}