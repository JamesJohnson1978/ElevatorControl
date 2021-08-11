using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevatorControl.Controllers
{
    /// <summary>
    /// API Endpoints to manipulate the Elevator
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private IState _state;

        /// <summary>
        /// Elevator controller to manage state
        /// </summary>
        /// <param name="state">State for the elevator</param>
        public ElevatorController(IState state)
        {
            _state = state;
        }

        /// <summary>
        /// Requests the elevator move to the specified floor
        /// </summary>
        /// <param name="id">Floor number elevator should move to</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        [HttpPost("{id}")]
        public IActionResult RequestFloor(int id)
        {
            Floor floor = new Floor() { Number = id };
            _state.AddFloor(floor);
            return Ok(floor);
        }

        /// <summary>
        /// Retrieves the current floors the elevator has been requested to service
        /// </summary>
        /// <returns>A list of current floors the elevator has been requested to service</returns>
        [HttpGet("floors")]
        public IActionResult GetFloors()
        {
            return Ok(_state.GetWorkQueue());
        }

        /// <summary>
        /// Obtains and removes the next floor from the elevators work queue
        /// </summary>
        /// <returns>The next floor in the work queue</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No more floors to service</response>
        [HttpGet("nextfloor")]
        public IActionResult NextFloor()
        {
            var nextFloor = _state.NextFloor();

            if (nextFloor == null)
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }

            return Ok(_state.NextFloor());
        }
    }
}
