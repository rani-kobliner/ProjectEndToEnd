using Bl.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            [FromQuery] DateOnly dateP,
            [FromQuery] string hour,
            [FromQuery] string minute,
            [FromQuery] string optometristCode)
        {
            try
            {
                TimeOnly parsedHour = TimeOnly.Parse(hour + ":" + minute);
                _queueBL.AddQueue(patientCode, dateP, parsedHour, optometristCode);
                return Ok("Queue successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding queue");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("removeQueue")]
        public IActionResult removeQueue(
            [FromQuery] string patientCode,
            [FromQuery] DateOnly dateP,
            [FromQuery] string hour,
            [FromQuery] string minute,
            [FromQuery] string optometristCode)
        {
            try
            {
                TimeOnly parsedHour = TimeOnly.Parse(hour + ":" + minute);
                _queueBL.RemoveQueue(patientCode, dateP, parsedHour, optometristCode);
                return Ok("Queue successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing queue");
                return BadRequest(ex.Message);
            }

        }
    }
}
