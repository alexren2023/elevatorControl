# elevatorControl

Alex Ren

csalexren@gmail.com

6178727872

#
Hello, this assignment is to build an Elevator Control System with .NET 
you can download the code, and use Visual Studio to run the program, and use PostMan to play with it!
there are clear comments on the service file, introducing the business logic.


The Elevator Control System that can manage multiple elevators, keeping track of their state while they go up and down floors. 
it should provide the following functionalities:

A person requests an elevator be sent to their current floor.

A person requests that they be brought to a floor.

An elevator car requests all floors that its current passengers are servicing. 

(e.g., to light up the buttons that show which floors the car is going to)

An elevator car requests the next floor it needs to service.

#

Therefore, after defining the model and interface, I built up the service with some other requirements.


Users can request the elevator to go to a specific floor.

Users can manually move the elevator to a specific floor.

Users can request the next floor the elevator will serve.

Users can view a list of all floors the elevator will serve in the future (Wait List).

Users can check the location of an elevator.

#

Some Sample Additional Features:

Users should not be able to request the elevator to floors that it does not serve (e.g., floor 500).

If the elevator is requested to go to the floor it's currently at, the system should not add that floor to the Wait List.

If the elevator is requested to go to a floor that's already last in its Wait List, the system should not add that floor to the list again.
