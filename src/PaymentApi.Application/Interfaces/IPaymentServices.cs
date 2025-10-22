using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.Interfaces
{
    public interface IPaymentServices
    {
        Task<PaymentResponse> CreatePayment(PaymentRequest request);
        Task<List<PaymentResponse>> GetPaymentsByStudent(Guid id, string state);
        Task<PaymentSuccessResponse> ConfirmPayment(Guid id, int days);
    }
}
