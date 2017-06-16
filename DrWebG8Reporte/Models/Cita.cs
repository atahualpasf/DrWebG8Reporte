using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrWebG8Reporte.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaConsulta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Empleado Doctor { get; set; }
        public virtual Empleado Secretaria { get; set; }
        public virtual Centro Centro { get; set; }

    }
}