using DotnetBackend.API.ModelViews;
using DotnetBackend.Core.DTO;
using DotnetBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DotnetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerService customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            this.logger = logger;
            this.customerService = customerService;
        }

        [Route("get-active-customers")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<IEnumerable<CustomerDTO>>))]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var result = await customerService.GetActiveCustomers();

                var response = new Response<IEnumerable<CustomerDTO>>()
                {
                    Code = "00",
                    Message = "Fetched Successfully",
                    IsSuccess = true,
                    Data = result.ToList()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was encountered while executing the action");
                return StatusCode(404, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }

        [Route("get-all-cuatomers")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<IEnumerable<CustomerDTO>>))]
        public IActionResult Get()
        {
            try
            {
                var result = customerService.GetAllCustomers();

                var response = new Response<IEnumerable<CustomerDTO>>()
                {
                    Code = "00",
                    Message = "Fetched Successfully",
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
