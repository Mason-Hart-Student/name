Lift Engine
@ 2018 Niwashi Games
Version 1.1

Lift Engine is a tool to make moving floor and rotating floor.

[Move Lift]
Set the path and move the floor.

[Rotate Lift]
Set the angle and rotate the floor.

[Wheel Lift]
Move the floor like a Ferris wheel.

[Base Transform]
Use it instead of 'Transform'.
When 'Preview' in 'Lift' is on, it moves based on 'Base Transform'.

[Ride Surface]
Sets the area where characters and other objects will be placed.

■How to use
1.Add component from 'Component -> Lift Engine'.
2.Set parameters in 'Inspector'.

- If you want to move from script
1.Write 'using GimmickEngine.Lift'.
2.Get the component of the lift.
3.Move with the Play function and stop with the Stop function.

■Version History
1.1
- Fix ListBase to LiftBase
- Add MoveLiftLite
- Add WheelLift
- Changed BaseTransform namespace from GimmickEngine.Lift.Core to GimmickEngine.Core.
1.0
- First release.