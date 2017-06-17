using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Direccion { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}