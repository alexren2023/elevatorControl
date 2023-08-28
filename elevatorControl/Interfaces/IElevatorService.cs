namespace elevatorControl.Interfaces
{
    public interface IElevatorService
    {
        int? GetCurrentFloor(string elevatorId);
        string RequestService(string elevatorId, int floor);
        int? GetNextFloor(string elevatorId);
        int[] GetAllService(string elevatorId);
        string MoveElevator(string elevatorId, int floor);
    }
}

/* Details and some corner situation will be find on service file: ElevatorService.cs
 *          
 * 
 * GetCurrentFloor is to get the current location of an elevator
 * RequestService is to let a elevator add a new place to go to in the waitlist
 * GetNextFloor just shows the next Floor one elevator is going to
 * GetAllService just shows the all the Floors  one elevator is going to as an array
 * MoveElevator can change the current location of an Elevator
 * 
 * 
 */