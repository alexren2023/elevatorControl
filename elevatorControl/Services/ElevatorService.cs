using System;
using System.Collections.Generic;
using elevatorControl.Interfaces;
using elevatorControl.Models;

namespace elevatorControl.Services
{
    public class ElevatorService : IElevatorService
    {
        private readonly Dictionary<string, Elevator> _elevators;

        public ElevatorService()
        {
            _elevators = new Dictionary<string, Elevator>
            {
                ["1"] = new Elevator
                {
                    ElevatorId = "1",
                    CurrentFloor = 1,
                    ServingFloors = new HashSet<int> { -5,-4,-3,-2,-1,1, 2, 3, 4, 5 ,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20},
                    WaitList = new List<int>()
                }
            };
        }

        /*
         * 
         * I generate a system that only has one elevator with id "1", start at the lobby/1st floor
         * with some certain Serving Floors
         * and a empty waitlist
         */
        public int? GetCurrentFloor(string elevatorId)
        {
            return _elevators.ContainsKey(elevatorId) ? _elevators[elevatorId].CurrentFloor : (int?)null;
        }
        /*
         * Check if the elevator with id is in the System, if so, return its location
         */
        public string RequestService(string elevatorId, int floor)
        {
            if (!_elevators.ContainsKey(elevatorId))
                return "Elevator not found";

            var elevator = _elevators[elevatorId];

            if (!elevator.ServingFloors.Contains(floor))
                return "Invalid floor";

            if (elevator.CurrentFloor == floor)
            {
                return "It is the current Floor";
            }
            if ( ! (elevator.WaitList.Count!=0 && elevator.WaitList.Last() == floor) )
            {
                elevator.WaitList.Add(floor);
            }
       
            return "Success";
        }
        /*
         * Different situations that for a specific elevator it cannot join the list:
         * first, the input of elevator id is not find
         * second, the input of floor is not the elevator can servce
         * third, it is the current location like u cannot go to the same floor.
         * 
         * Then, if it is the same as its Newest location it will not be added in the list, but the request is successful
         * like the new person will go to the same location.
         */

        public int? GetNextFloor(string elevatorId)
        {
            if (!_elevators.ContainsKey(elevatorId))
                return null;

            var elevator = _elevators[elevatorId];
            return elevator.WaitList.Count > 0 ? elevator.WaitList[0] : (int?)null;
        }

        /*
         * Different situations that for a specific elevator it cannot join the list:
         * first, the input of elevator id is not find
         * second, the elevator is not going anywhere
         */

        public int[] GetAllService(string elevatorId)
        {
            if (!_elevators.ContainsKey(elevatorId))
                return Array.Empty<int>();

            var elevator = _elevators[elevatorId];
            return elevator.WaitList.ToArray();
        }
        /*
         * return the waitlist/ the locations the elevator is going to in the future 
         *      if we can find this elevator
         */
        public string MoveElevator(string elevatorId, int floor)
        {
            if(!_elevators.ContainsKey(elevatorId))
                return "Elevator not found";

            var elevator = _elevators[elevatorId];

            //if (floor < -10 || floor > 30 || floor == 0)
            //    return "Invalid floor";
            if (!elevator.ServingFloors.Contains(floor))
            {
                return "Invalid floor";
            }
            
            if (elevator.CurrentFloor == floor)
            {
                return "It is the current Floor";
            }

            elevator.CurrentFloor = floor;

            if (elevator.WaitList.Count > 0 && elevator.WaitList[0] == floor)
            {
                elevator.WaitList.RemoveAt(0);
            }
            return "Success";
        }
        /*
         * Change the location of a elevator:
         * it will fail if we don't have this elevator
         * it will fail if we don't have the floor as serving floor for that elevator
         * the location will not change if it remains as the same floor
         * if it achieve the first location we want in the list, we will remove that from the waitList.
         */
    }
}

