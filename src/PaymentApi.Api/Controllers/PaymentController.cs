using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.Interfaces;

namespace PaymentApi.Api.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest request)
        {
            var response = await _paymentServices.CreatePayment(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPayment([FromRoute] Guid id)
        {
            var response = await _paymentServices.GetPayment(id);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> FilterPayments([FromQuery] PaymentFilterRequest request)
        {
            var response = await _paymentServices.GetFilterPayments(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("confirm/{id}")]
        public async Task<IActionResult> ConfirmPayment([FromRoute] Guid id, [FromQuery] int days)
        {
            var response = await _paymentServices.ConfirmPayment(id, days);
            return Ok(response);
        }
    }
}
