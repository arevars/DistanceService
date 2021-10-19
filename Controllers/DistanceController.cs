using AutoMapper;
using DistanceService.Interfaces;
using DistanceService.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DistanceService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDistanceService _service;

        public DistanceController(
            IMapper mapper,
            IDistanceService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
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
