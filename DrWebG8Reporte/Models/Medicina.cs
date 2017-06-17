using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Medicina : RecursoHospitalario
    {
        public string Componentes { get; set; }
        public string Posologia { get; set; }
        public string Recomendaciones { get; set; }
    }
}