using Microsoft.EntityFrameworkCore;
using PaymentApi.Application.Interfaces;
using PaymentApi.Domain.Entities;
using PaymentApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Infrastructure.Queries
{
    public class PaymentQuery : IPaymentQuery
    {
        private readonly AppDbContext _context;
        public PaymentQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> GetPayment(Guid id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
            return payment;
        }

        public async Task<List<Payment>> GetPaymentsByStudent(Guid id)
        {
            var payments = await _context.Payments.Where(p => p.Alumno_Id == id).ToListAsync();
            return payments;
        }
    }
}
