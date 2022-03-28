using DotnetBackend.API.ModelViews;
using DotnetBackend.Core.DTO;
using DotnetBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DotnetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetalPriceController : ControllerBase
    {
        private readonly IMetalPriceService metalPriceService;
        private readonly ILogger<MetalPriceController> logger;

        public MetalPriceController(IMetalPriceService metalPriceService, ILogger<MetalPriceController> logger)
        {
            this.metalPriceService = metalPriceService;
            this.logger = logger;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<GoldSilverResponse>))]
        public async Task<IActionResult> Get()
        {
            try
            {

                var result = await metalPriceService.GetGoldSilverPrice();

                var response = new Response<GoldSilverResponse>()
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
