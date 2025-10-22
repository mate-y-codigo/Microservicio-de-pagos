using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.Interfaces
{
    public interface IPaymentQuery
    {
        Task<List<Payment>> GetPaymentsByStudent(Guid id);
        Task<Payment> GetPayment(Guid id);
    }
}
