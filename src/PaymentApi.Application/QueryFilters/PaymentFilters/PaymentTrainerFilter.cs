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
    public class PaymentTrainerFilter : IQueryFilter<Payment,PaymentFilterRequest>
    {
        public IQueryable<Payment> Aplly(IQueryable<Payment> query, PaymentFilterRequest request)
        {
            if (request.Entrenador_Id.HasValue)
            {
                query = query.Where(p => p.Entrenador_Id == request.Entrenador_Id.Value);
            }
            return query;
        }
    }
}
