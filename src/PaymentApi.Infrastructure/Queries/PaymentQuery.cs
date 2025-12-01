using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.Interfaces;
using PaymentApi.Application.QueryFilters.PaymentFilters;
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

        public async Task<Payment> GetStudentLastPayment(Guid id)
        {
            //var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Alumno_Id == id);
            var payment = await _context.Payments
                .Where(p => p.Alumno_Id == id)
                .OrderByDescending(p => p.Pagado_El)
                .FirstOrDefaultAsync();

            return payment;
        }

        public async Task<List<Payment>> FilterPayments(PaymentFilterRequest request)
        {
            var filters = new List<IQueryFilter<Payment, PaymentFilterRequest>>
                {
                    new PaymentStudentFilter(),
                    new PaymentTrainerFilter(),
                    new PaymentStatusFilter(),
                    new PaymentMethodFilter(),
                    new PaymentFromDateFilter(),
                    new PaymentToDateFilter() 
                };
            var query = _context.Payments.AsQueryable();
            foreach (var filter in filters)
            {
                query = filter.Aplly(query, request);
            }
            return await query.ToListAsync();
        }

        public async Task<Payment> GetPaymentValidateCoverage(Guid student_id)
        {
            var timenow = DateTime.UtcNow.Date;
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p =>
                    p.Cobertura_Inicio <= timenow &&
                    p.Cobertura_Fin >= timenow &&
                    p.Alumno_Id == student_id);
            return payment;

        }
    }
}
