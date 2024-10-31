# 2D Inverse Kinematics Armature
![2D_IK_Simple](https://github.com/user-attachments/assets/771e7096-6271-4fad-81bf-f45748e00489)

# Basic Functionality
This is not my own creation, my understanding and the implementation of this comes from ![this video](https://www.youtube.com/watch?v=VdJGouwViPs&t=927s), I only recreated it with the intent to learn and build off of it.

Only two classes are needed to make this work, one for the Joints themselves, and one to manage and calculate the rotation needed for each Joint.

| Joint Class | IK Manager Class |
| :-: | :-: |
| ![Joint Class](https://github.com/user-attachments/assets/63483057-caad-4dbb-981b-a39aa36fa013) | ![IK_Manager Class](https://github.com/user-attachments/assets/ec1abfed-0f90-415f-b03e-9af1321e8b86) |

## Calculating Rotation
The rotation of each joint is calculated by:
- Finding the distance between the root joint and the target,
- Rotating the joint by a set amount (0.01 radians),
- Finding the new distance between joint and target,
- Then rotating back to its original position,
Then, we go move to the child node and repeat

Using this, we can work out the gradient of the graph of Distance (to target) over Angle (of Joint), which tells us the direction to rotate the object, and how much to rotate the it by.
![Graph](https://github.com/user-attachments/assets/124a7910-a995-41ae-b80a-076c94ed2855)
