using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.Interfaces
{
    public interface IPaymentCommand
    {
        Task CreatePayment(Payment payment);
        Task ConfirmPayment(Payment payment, int days);
    }
}
