using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response
{
    public class PaymentSuccessResponse
    {
        public Guid Id { get; set; }
        public string? Estado { get; set; }
        public DateTime? Pagado_El { get; set; }
        public DateTime? Cobertura_Inicio { get; set; }
        public DateTime? Cobertura_Fin { get; set; }

    }
}
