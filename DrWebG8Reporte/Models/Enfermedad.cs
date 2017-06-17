using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}