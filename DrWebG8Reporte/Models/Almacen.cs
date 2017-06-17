using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Almacen
    {
        public int Id { get; set; }
        public int Disponible { get; set; }

        public virtual Centro Centro { get; set; }
        public virtual RecursoHospitalario RecursoHospitalario { get; set; }
    }
}