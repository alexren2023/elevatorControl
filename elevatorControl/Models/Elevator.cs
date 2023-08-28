using System.Collections.Generic;

namespace elevatorControl.Models
{
    public class Elevator
    {
        public string? ElevatorId { get; set; }
        public int CurrentFloor { get; set; }
        public HashSet<int> ServingFloors { get; set; } = new HashSet<int>();
        public List<int> WaitList { get; set; } = new List<int>();
    }
}

/* Hello,
 * Here is the elevator as model, 
 * 
 * for each elevator, we have
 * ElevatorId       as its uniqueID 
 * CurrentFloor     as its current location (int the building etc)
 * ServingFloors    as the floors it can go to, some elevators only work for odd floors, some only work for 20 above etc
 * WaitList         as the floors the elevator is going to in the future.
 * 
 * 
 */