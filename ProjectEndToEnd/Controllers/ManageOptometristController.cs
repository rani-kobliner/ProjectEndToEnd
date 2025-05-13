using Dal.Api;
using Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOptometristController : ControllerBase
    {
        private readonly ILogger<ManageOptometristController> _logger;
        private readonly IOptometrist _optometrist;
        public ManageOptometristController(ILogger<ManageOptometristController> logger, IOptometrist optometrist)
        {
            _logger = logger;
            _optometrist = optometrist;
        }

        [HttpPut("addOptometrist")]
        public IActionResult AddOptometris([FromBody] string id, string firstName, string lastName,
            string gender, int specializationByAge)
        {
            try
            {
                _optometrist.addOptometrist(id, firstName, lastName, gender, specializationByAge);
                _logger.LogInformation("Optometrist successfully added");
                return Ok("Optometrist successfully added");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while added the Optometrist.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("removeOptometrist")]
        public IActionResult removeOptometrist([FromBody] string id)
        {
            try
            {
                _optometrist.removeOptometrist(id);
                return Ok($"Optometrist with ID {id} removed successfully removed.");

            }
            catch (KeyNotFoundException)
            {
                return NotFound($"optometrist with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing the optometrist.");
                return StatusCode(500, "Internal server error.");
            }

        }

    }
}
