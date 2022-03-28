using DotnetBackend.API.ModelViews;
using DotnetBackend.Core.DTO;
using DotnetBackend.Core.Entities;
using DotnetBackend.Data.Repositories;
using DotnetBackend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DotnetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> logger;
        private readonly ILocationService locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            this.locationService = locationService;
            this.logger = logger;
        }

        [Route("get-states")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<IEnumerable<StateDTO>>))]
        public IActionResult Get()
        {
            try
            {
                var result = locationService.GetAllStates();

                var response = new Response<IEnumerable<StateDTO>>()
                {
                    Code = "00",
                    Message = "Fetched Successfully",
                    IsSuccess = true,
                    Data = result
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was encountered while executing the action");
                return StatusCode(404, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }

        [Route("get-lgas")]
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)] // "application/json"
        [Produces(typeof(Response<LGADTO>))]
        public IActionResult GetLGAsPerState(long stateId)
        {
            try
            {
                if (stateId <= 0)
                {
                    return BadRequest(new { IsSuccess = false, Code = "01", Message = $"StateId is required" });
                }

                var result = locationService.GetLGAs(stateId);

                var response = new Response<LGADTO>()
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
                return StatusCode(500, new { IsSuccess = false, Code = "99", Message = $"Error: {ex.Message}" });
            }
        }
    }
}
