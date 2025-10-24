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
    public class PaymentFromDateFilter : IQueryFilter<Payment, PaymentFilterRequest>
    {
        public IQueryable<Payment> Aplly(IQueryable<Payment> query, PaymentFilterRequest request)
        {
            if (request.Desde.HasValue)
            {
                query = query.Where(p => DateOnly.FromDateTime(p.Creado_En) >= request.Desde.Value);
            }
            return query;
        }
    }
}
