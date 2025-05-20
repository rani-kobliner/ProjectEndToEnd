using Bl.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class ManageQueueController:ControllerBase
    {
        private readonly ILogger<ManageQueueController> _logger;
        private readonly IQueueBL _queueBL;

        public ManageQueueController(ILogger<ManageQueueController> logger,
                IQueueBL queueBL)
        {
            _logger = logger;
            _queueBL = queueBL;
        }

        [HttpPost("addQueue")]
        public IActionResult AddQueue(
            [FromQuery] string patientCode,
            [FromQuery] DateOnly date,
            [FromQuery] TimeOnly hour,
            [FromQuery] string optometristCode)
        {
            try
            {
                _queueBL.AddQueue(patientCode, date, hour, optometristCode);
                return Ok("Queue successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding queue");
                return BadRequest(ex.Message);
            }
        }
    }
}
