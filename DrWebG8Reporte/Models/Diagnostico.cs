using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public string Observacion { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}