using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanceService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly ILogger<DistanceController> _logger;
        private readonly IMapper _mapper;

        public DistanceController(ILogger<DistanceController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult GetDistance()
        //{
        //    return 
        //}
    }
}
