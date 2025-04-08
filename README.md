# 2D Inverse Kinematics Armature
<img src="https://github.com/user-attachments/assets/771e7096-6271-4fad-81bf-f45748e00489" width="400">

This is a very basic implementation of Inverse Kinematics, calculating the rotation of each joint based on the distance between the End Joint and the Target.

Note: This is not my own design, my understanding and the implementation of this comes from [this video](https://www.youtube.com/watch?v=VdJGouwViPs&t=927s), I only recreated it with the intent to learn and build from it.

## How it Works
The rotation of each joint is calculated by:
- Finding the distance between the end joint and the target,
- Rotating the root joint by a set amount (0.01 degrees),
- Finding the new distance between end joint and target,
- Moving the joint back to its original position,
- Estimating the gradient between the two points,
- Rotating the joint based off of the gradient calculated (see graph below)
Then, we move to the next joint and repeat

The graph below shows the Distance (between the end joint and the target) against the Angle (of rotation from 0) of a two-joint arm.
This concept works the same with multiple joints, but the graph will be much less uniform.

<img src="https://github.com/user-attachments/assets/86661d07-3f12-4acb-8942-1127aa7c1357" width="500">

## Improvements to make
- Making it in 3D
- Adding constraints to the joints (so each joint has a limited range of motion)
- Adding a Pole (a direction for the arm to tend towards when bent)
- Using a different algorithm (FABRIC)
- Adding objects to move around (use A* pathfinding)

