using Dal.Api;
using Dal.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dal.models.Patient;

namespace server.controllers
{   
    [ApiController]
    [Route("api/[controller]")]
 
    public class ManagePatientsController : ControllerBase
    {
        private readonly ILogger<ManagePatientsController> _logger;
        private readonly IPatient _patient;

        public ManagePatientsController(ILogger<ManagePatientsController> logger, IPatient patient)
        {
            _logger = logger;
            _patient = patient;
        }

        [HttpPost("AddPatient")]
        public IActionResult AddPatient([FromQuery] string id, [FromQuery] string fName, [FromQuery] string lName,
            [FromQuery] DateOnly birthday, [FromQuery] string gender, [FromQuery] string hmo)
        {
            if(!Enum.TryParse<HmoType>(hmo, true, out var _))
            {
                return BadRequest("Invalid HMO type specified. Valid options are: Klalit, Macabi, Leumit, Meuhedet.");
            }
            _patient.AddPatient(id, fName, lName, birthday, gender, hmo);
            return Ok( $"{fName} {lName} was successfully added to the customer database!");
        }


        [HttpDelete("RemovePatient")]
        public IActionResult RemovePatient([FromBody] string id)
        {
            try
            {
                _patient.RemovePatient(id);
                return Ok($"Patient with ID {id} removed successfully.");

            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Patient with ID {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing the patient.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("UpdatePatient")]
        public IActionResult UpdatePatient([FromQuery] string id, [FromQuery] string hmo)
        {
            if (!Enum.TryParse<HmoType>(hmo, true, out var parsedHmo))
            {
                return BadRequest("Invalid HMO type specified. Valid options are: Klalit, Macabi, Leumit, Meuhedet.");

            }
            bool p_success = _patient.UpdatePatient(id, parsedHmo.ToString());
            if (!p_success)
            {
                return NotFound($"Patient with ID {id} not found.");

            }
            return Ok($"HMO {parsedHmo} has been successfully updated for patient {id}");

        } 

    }
}
