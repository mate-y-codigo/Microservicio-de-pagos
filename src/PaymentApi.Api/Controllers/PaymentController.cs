using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Application.CustomExceptions;
using PaymentApi.Application.DTOs.Request;
using PaymentApi.Application.DTOs.Response;
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
        [ProducesResponseType(typeof(PaymentResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest request)
        {
            var result = await _paymentServices.CreatePayment(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PaymentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPayment([FromRoute] Guid id)
        {
            try
            {
                var result = await _paymentServices.GetPayment(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ApiError { Message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiError { Message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> FilterPayments([FromQuery] PaymentFilterRequest request)
        {
            var response = await _paymentServices.GetFilterPayments(request);
            return Ok(response);
        }

        [HttpPatch]
        [Route("confirm/{id}")]
        [ProducesResponseType(typeof(PaymentSuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConfirmPayment([FromRoute] Guid id, [FromQuery] int dias)
        {
            try
            {
                var result = await _paymentServices.ConfirmPayment(id, dias);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ApiError { Message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiError { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("Validate/{id}")]
        [ProducesResponseType(typeof(PaymentSuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateCoverage([FromRoute] Guid id)
        {
            try
            {
                var result = await _paymentServices.ValidateCoverage(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ApiError { Message = ex.Message });
            }
        }
        [HttpPatch]
        [Route("Decline/{id}")]
        [ProducesResponseType(typeof(PaymentSuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeclinePayment([FromRoute] Guid id)
        {
            try
            {
                var result = await _paymentServices.DeclinePayment(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ApiError { Message = ex.Message });
            }
        }
    }
}
