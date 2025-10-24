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
    public class PaymentMethodFilter : IQueryFilter<Payment, PaymentFilterRequest>
    {
        public IQueryable<Payment> Aplly(IQueryable<Payment> query, PaymentFilterRequest request)
        {
            var metodo = request.Metodo?.ToLower();
            if (!string.IsNullOrWhiteSpace(metodo))
                query = query.Where(p => p.Metodo.ToLower().Contains(metodo));
            return query;
        }
    }
}
