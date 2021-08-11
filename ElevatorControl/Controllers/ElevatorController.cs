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
        /// <param name="id">Floor number the elevator should arrive at</param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        [HttpPut("{id}")]
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
        [HttpGet("")]
        public IActionResult GetFloors()
        {
            return Ok(_state.GetWorkQueue());
        }

        /// <summary>
        /// Obtains and removes the next floor from the elevators work queue
        /// </summary>
        /// <remarks>Removes this floor from the existing work queue</remarks>
        /// <returns>The next floor in the work queue</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No more work in the elevators queue</response>
        [HttpDelete("")]
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
