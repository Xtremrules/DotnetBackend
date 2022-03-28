using DotnetBackend.API.ModelViews;
using DotnetBackend.Core.DTO;
using DotnetBackend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DotnetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboaringController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerService customerService;

        public OnboaringController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            this.logger = logger;
            this.customerService = customerService;
        }

        [Route("creat-customer")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<CustomerDTO>))]
        public async Task<IActionResult> CreateCustomer(Customer coustomerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errs = ModelState.Values.Where(v => v.Errors.Count > 0).Select(v => v.Errors.First().ErrorMessage);
                    return StatusCode(400, new { IsSuccess = false, Message = "One or more fields failed validation", ErrorItems = errs });
                }

                var customer = await customerService.CreateCustomer(coustomerVM);

                var response = new Response<CustomerDTO>()
                {
                    Code = "00",
                    Message = "Customer Created Successfully",
                    IsSuccess = true,
                    Data = customer
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was encountered while executing the action");
                return StatusCode(404, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }

        [Route("validate-token")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<IEnumerable<CustomerDTO>>))]
        public async Task<IActionResult> ValidateToken(OTPValidateRequest validateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errs = ModelState.Values.Where(v => v.Errors.Count > 0).Select(v => v.Errors.First().ErrorMessage);
                    return StatusCode(400, new { IsSuccess = false, Message = "One or more fields failed validation", ErrorItems = errs });
                }

                var customer = await customerService.ActivateCustomer(validateRequest);

                var response = new Response<CustomerDTO>()
                {
                    Code = "00",
                    Message = "Token validated Successfully",
                    IsSuccess = true,
                    Data = customer
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was encountered while executing the action");
                return StatusCode(404, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }

        [Route("get-active-customers")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<IEnumerable<CustomerDTO>>))]
        public async Task<IActionResult> ResendOtp(OTPRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errs = ModelState.Values.Where(v => v.Errors.Count > 0).Select(v => v.Errors.First().ErrorMessage);
                    return StatusCode(400, new { IsSuccess = false, Message = "One or more fields failed validation", ErrorItems = errs });
                }

                var result = await customerService.ResendOTP(request);

                var response = new Response<string>()
                {
                    Code = "00",
                    Message = "Successfully",
                    IsSuccess = true,
                    Data = result
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was encountered while executing the action");
                return StatusCode(404, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }
    }
}
