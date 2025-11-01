using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.DTOs.Response;
using PaymentApi.Application.Interfaces;
using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentCommand _paymentCommand;
        private readonly IPaymentQuery _paymentQuery;

        public PaymentServices(IPaymentCommand paymentCommand, IPaymentQuery paymentQuery)
        {
            _paymentCommand = paymentCommand;
            _paymentQuery = paymentQuery;
        }


        public async Task<PaymentResponse> CreatePayment(PaymentRequest request)
        {
            var payment = new Payment
            {
                Alumno_Id = request.Alumno_Id,
                Entrenador_Id = request.Entrenador_Id,
                Monto = request.Monto,
                Moneda = request.Moneda,
                Metodo = request.Metodo,
                Notas = request.Notas
            };
            await _paymentCommand.CreatePayment(payment);
            var createdPayment = await _paymentQuery.GetPayment(payment.Id);
            return new PaymentResponse
            {
                Id = createdPayment.Id,
                Alumno_Id = createdPayment.Alumno_Id,
                Entrenador_Id = createdPayment.Entrenador_Id,
                Monto = createdPayment.Monto,
                Moneda = createdPayment.Moneda,
                Metodo = createdPayment.Metodo,
                Estado = createdPayment.Estado,
                Notas = createdPayment.Notas,
                Creado_En = createdPayment.Creado_En,
                Pagado_El = createdPayment.Pagado_El,
                Cobertura_Inicio = createdPayment.Cobertura_Inicio,
                Cobertura_Fin = createdPayment.Cobertura_Fin
            };
        }

        public async Task<PaymentSuccessResponse> ConfirmPayment(Guid id, int days)
        {
            var payment = _paymentQuery.GetPayment(id);
            await _paymentCommand.ConfirmPayment(await payment, days);
            var paymentConfirmed = await _paymentQuery.GetPayment(id);
            return new PaymentSuccessResponse
            {
                Id = paymentConfirmed.Id,
                Estado = paymentConfirmed.Estado,
                Pagado_El = paymentConfirmed.Pagado_El,
                Cobertura_Inicio = paymentConfirmed.Cobertura_Inicio,
                Cobertura_Fin = paymentConfirmed.Cobertura_Fin
            };
        }

        public async Task<List<PaymentResponse>> GetFilterPayments(PaymentFilterRequest request)
        {
            var payments = await _paymentQuery.FilterPayments(request);
            return payments.Select(p => new PaymentResponse
            {
                Id = p.Id,
                Alumno_Id = p.Alumno_Id,
                Entrenador_Id = p.Entrenador_Id,
                Monto = p.Monto,
                Moneda = p.Moneda,
                Metodo = p.Metodo,
                Estado = p.Estado,
                Notas = p.Notas,
                Creado_En = p.Creado_En,
                Pagado_El = p.Pagado_El,
                Cobertura_Inicio = p.Cobertura_Inicio,
                Cobertura_Fin = p.Cobertura_Fin
            }).ToList();
        }

        public async Task<PaymentResponse> GetPayment(Guid id)
        {
            var payment = await _paymentQuery.GetPayment(id);
            return new PaymentResponse
            {
                Id = payment.Id,
                Alumno_Id = payment.Alumno_Id,
                Entrenador_Id = payment.Entrenador_Id,
                Monto = payment.Monto,
                Moneda = payment.Moneda,
                Metodo = payment.Metodo,
                Estado = payment.Estado,
                Notas = payment.Notas,
                Creado_En = payment.Creado_En,
                Pagado_El = payment.Pagado_El,
                Cobertura_Inicio = payment.Cobertura_Inicio,
                Cobertura_Fin = payment.Cobertura_Fin
            };
        }

        public async Task<PaymentValidateCoverage> ValidateCoverage(Guid student_id)
        {
            var payment = await _paymentQuery.GetPaymentValidateCoverage(student_id);
            if (payment != null)
            {
                return new PaymentValidateCoverage
                {
                    EstaCubierto = true,
                    DiasRestantes = payment.Cobertura_Fin.HasValue? Math.Max(0, (payment.Cobertura_Fin.Value.Date - DateTime.UtcNow.Date).Days): 0,
                    FechaExpiracion = payment.Cobertura_Fin
                };
            }
            else
            {
                return new PaymentValidateCoverage
                {
                    EstaCubierto = false,
                    DiasRestantes = null,
                    FechaExpiracion = null,
                };

            }
        }
    }
}
