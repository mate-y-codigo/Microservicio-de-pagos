using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Request
{
    public class PaymentRequest
    {
        public Guid Alumno_Id { get; set; }
        public Guid Entrenador_Id { get; set; }
        public decimal Monto { get; set; }
        public required string Moneda { get; set; }
        public required string Metodo { get; set; }
        public string? Notas { get; set; }
    }
}
