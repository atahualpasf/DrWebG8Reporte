using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Motivo { get; set; }

        public virtual ICollection<Implemento> Implementos { get; set; }
        public virtual Enfermedad Enfermedad { get; set; }
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual ICollection<UsoRecurso> RecursosUsados { get; set; }
    }
}