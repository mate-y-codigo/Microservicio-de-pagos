using PaymentApi.Application.Interfaces;
using PaymentApi.Domain.Entities;
using PaymentApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Infrastructure.Commands
{
    public class PaymentCommand : IPaymentCommand
    {
        private readonly AppDbContext _context;
        public PaymentCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreatePayment(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
        }
        public async Task ConfirmPayment(Payment payment, int days)
        {
            payment.Estado = "Confirmado";
            payment.Pagado_El = DateTime.UtcNow;
            var now = DateTime.UtcNow.Date;
            payment.Cobertura_Inicio = now;
            payment.Cobertura_Fin = now.AddDays(days).AddHours(23).AddMinutes(59).AddSeconds(59);
            await _context.SaveChangesAsync();
        }
    }
}
