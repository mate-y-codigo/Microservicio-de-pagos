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
    public class PaymentStudentFilter : IQueryFilter<Payment, PaymentFilterRequest>
    {
        public IQueryable<Payment> Aplly(IQueryable<Payment> query, PaymentFilterRequest request)
        {
            if (request.Alumno_Id.HasValue)
            {
                query = query.Where(p => p.Alumno_Id == request.Alumno_Id.Value);
            }
            return query;
        }
    }
}
