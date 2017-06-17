using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class UsoRecurso
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        public virtual RecursoHospitalario RecursoHospitalario { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}