using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Centro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rif { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}