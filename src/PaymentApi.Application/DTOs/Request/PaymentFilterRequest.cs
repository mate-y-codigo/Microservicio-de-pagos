using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Request
{
    public class PaymentFilterRequest
    {
        public Guid? Alumno_Id { get; set; }
        public Guid? Entrenador_Id { get; set; }
        public DateOnly? Desde { get; set; }
        public DateOnly? Hasta { get; set; }
        public string? Metodo { get; set; }
        public string? Estado { get; set; }
    }
}
