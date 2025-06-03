The project contains the source code of a journal paper titled "Dendrite-Inspired and 3D Printed Multidirectional Sensing Piezoresistive Metamaterials."

**Citation Format:**
L. Zhang, Y. Bian, W. Wei, Z. Liao, M. Cang, A. Yang, H. Zhi, W. Zhang, M. Chen, H. Cui, Y. Cai, "Dendrite-Inspired and 3D Printed Multidirectional Sensing Piezoresistive Metamaterials," *Advanced Functional Materials*, 2025, 2508987. https://doi.org/10.1002/adfm.202508987


This project requires the use of four devices: a computer running Unity (version 2021.3.16f), an AR glass HoloLens 2, an Arduino (specifically a Uno for this project), and a robot hand. 

Asset:

To integrate the necessary asset into the Mixed Reality Toolkit 3 (MRTK3) project, it must be copied to the designated path within the MRTK3 project. The asset should be replaced in the specified directory within the project structure. For detailed instructions, please refer to the [MixedRealityToolkit-Unity](https://github.com/MixedRealityToolkit/MixedRealityToolkit-Unity) repository on GitHub.

Two main scenes are included in the project: CUBE_Color and HandVisualizer. The CUBE_Color scene facilitates color changes based on sensor values, while the HandVisualizer scene is used for controlling the robot hand.

Demo:


https://github.com/user-attachments/assets/5ab00b73-3ceb-4b77-abe3-2c6030c18e03

https://github.com/user-attachments/assets/19c50115-9a5e-4922-a0ea-51bdcfc0a2af





For the hololens 2, we used the Holographic Remoting Player to project the virtual unity sence to the AR glass.

Key components of the project include:

- Server: Responsible for communication with the robot arm via IP.
![image](https://github.com/user-attachments/assets/c7cb1819-ffb0-4a67-a511-8d60806867ab)

- Communication: Facilitates communication with the Arduino device through the serial port.
![image](https://github.com/user-attachments/assets/478dd78c-6411-4e21-87a7-dc8f885047f2)


- uHand: Contains the necessary code for controlling and communicating with Unity via IP.

- 0827_objects_capture: Code segment for Arduino to obtain sensor values from the cube.

The image below shows the robot hand of the project.

![image](https://github.com/user-attachments/assets/5f1f47f1-fd31-4c2a-adb6-33a2ec849088)




