using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid Alumno_Id { get; set; }
        public Guid Entrenador_Id { get; set; }
        public decimal Monto { get; set; }
        public required string Moneda { get; set; }
        public DateTime? Pagado_El { get; set; }
        public DateTime? Cobertura_Inicio { get; set; }
        public DateTime? Cobertura_Fin { get; set; }
        public required string Metodo { get; set; }
        public string? Estado { get; set; }
        public string? Notas { get; set; }
        public DateTime Creado_En { get; set; }
    }
}
