Mars Rover Problem
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is curiously rectangular, must be navigated by the rovers so that their on-board cameras can get a complete map of the surrounding terrain to send back to Earth.
A rover's position and location are represented by a combination of x and y coordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.
In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point and maintain the same heading.
Assume that the square directly North from (x, y) is (x, y+1).

Additional Information
It is assumed that the first action is to define the upper-right coordinates (5, 5) of the Plateau.
Once completed, rover objects can be deployed within the plateau. Each rover should be able to take a series of commands following the simple letter commands outlined above.
In the test we will be providing a movements.csv, this file will outline each rover and it’s predefined movements, this information should be sent to the plateau to automate the process of mapping the surroundings.
Each rover should be sequential, meaning the second rover will only complete its tasks once the rover before it has finished moving.
Additional rovers can optionally be added with the ability to define both starting location and movements.
Each line in the movements.csv file represents an independent rover, these lines are then split by a pipe, on the left of the pipe is the rover starting position and on the right of the pipe is the rover's movements.

How do you test Test:
Run the application with startup project as website(MarsRovers) and upload the Movements csv file with the input given below and you would see the output as mentioned below.

Unit testing Configured with Nunit.

INPUT:

Movements CSV File (For Reference)

1 2 N|LMLMLMLMM
3 3 E|MMRMMRMRRM


OUTPUT:

1 3 N
5 1 E

