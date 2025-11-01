using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.DTOs.Response
{
    public class PaymentValidateCoverage
    {
        public bool EstaCubierto { get; set; }
        public int? DiasRestantes { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}
