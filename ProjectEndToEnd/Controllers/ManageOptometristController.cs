using Dal.Api;
using Microsoft.AspNetCore.Mvc;
using Bl.Api;
using Bl.Models;

namespace server.controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ManageOptometristController : ControllerBase
    {
        private readonly ILogger<ManageOptometristController> _logger;
        private readonly IOptometristBL _optometristBL;

        public ManageOptometristController(ILogger<ManageOptometristController> logger,
            IOptometristBL optometristBL)
        {
            _logger = logger;
            _optometristBL = optometristBL;
        }

        [HttpPost("addOptometrist")]
        public IActionResult AddOptometrist(
            [FromQuery] ManagementOptometristBL optometrist)
        {
            try
            {
                _optometristBL.AddOptometrist(optometrist);
                return Ok("Optometrist successfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding optometrist");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("removeOptometrist/{id}")]
        public IActionResult RemoveOptometrist(string id)
        {
            try
            {
                _optometristBL.RemoveOptometrist(id);
                return Ok($"Optometrist with ID {id} removed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing optometrist");
                return BadRequest(ex.Message);
            }
        }
    }
}