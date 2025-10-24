using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.Interfaces;
using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.QueryFilters.PaymentFilters
{
    public class PaymentStatusFilter : IQueryFilter<Payment,PaymentFilterRequest>
    {
        public IQueryable<Payment> Aplly(IQueryable<Payment> query, PaymentFilterRequest request)
        {
            var estado = request.Estado?.ToLower();
            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(p => p.Estado.ToLower().Contains(estado));
            return query;
        }
    }
}
