using DistanceService.Interfaces;
using DistanceService.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DistanceService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _service;

        public DistanceController(IDistanceService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetDistance(GetDistanceRequestModel request)
        {
            try
            {
                var result = await _service.GetDistance(request);
                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return BadRequest();
        }
    }

}
