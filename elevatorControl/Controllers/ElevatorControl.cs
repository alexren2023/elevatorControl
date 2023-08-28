using Microsoft.AspNetCore.Mvc;
using elevatorControl.Interfaces;
using elevatorControl.Models;

namespace elevatorControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorService _elevatorService;

        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        [HttpPost("request")]
        public ActionResult<string> RequestElevator(string elevatorId, int floor)
        {
            var result = _elevatorService.RequestService(elevatorId, floor);
            if (result != "Success")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("nextFloor")]
        public ActionResult<int?> GetNextFloorToService(string elevatorId)
        {
            var result = _elevatorService.GetNextFloor(elevatorId);
            if (result == null)
            {
                return NotFound("Elevator or next floor not found");
            }
            return Ok(result);
        }

        [HttpGet("allFloors")]
        public ActionResult<int[]> GetAllServiceList(string elevatorId)
        {
            var result = _elevatorService.GetAllService(elevatorId);
            if (result.Length == 0)
            {
                return NotFound("Elevator or floors not found");
            }
            return Ok(result);
        }

        [HttpPost("move")]
        public ActionResult MoveElevator(string elevatorId, int floor)
        {
            var result=_elevatorService.MoveElevator(elevatorId, floor);
            if (result != "Success"){
                return BadRequest(result);
            }
            return Ok("Elevator moved");
        }

        [HttpGet("currentFloor")]
        public ActionResult<int?> GetCurrentFloor(string elevatorId)
        {
            var result = _elevatorService.GetCurrentFloor(elevatorId);
            if (result == null)
            {
                return NotFound("Elevator not found");
            }
            return Ok(result);
        }
    }
}
/*
 *  the controller layer is calling the methods from the service layer,
 *  and the comments are mainly in the interface and service.
 */