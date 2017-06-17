using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Historia
    {
        public int Id { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}