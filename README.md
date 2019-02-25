# ForestDronController
The Yellowstone’s park control forest fires team is setting up a group of drones for overflying the park area performing heat detection.

## Getting Started
To launch the program there are a few options:
 * Launch with Visual Studio:
    - Clone the repository: git clone https://github.com/didaccs/ForestDronController.git
    - Open with VisualStudio and press to RUN or F5 
 * Launch the published Application
    - Download the <a href="https://github.com/didaccs/ForestDronController/releases">Last Release</a>
    - Unzip the file
    - Execute the 'ForestDronConsole.exe' or with the command console execute 'dotnet ForestDronConsole.dll'
To compile a self packaged application (EXE file):
 - Execute 'dotnet publish --self-contained -c Release --runtime win-x64'

## Project description 
In the solution 'ForestDronController.sln' there are three projects:
 1. ForestDronConsole: The project to input the instructions
 2. ForestDronController: The project to manage instructions and make the movements for every dron
 3. TestForestDronController: The project that contains the test for the project 'ForestDronController'

##  Initial requirements
We send all the instructions at once.
 * First line defines the flying area, specified by a rectangle representing the drones movement area.
 * Next line defines the dron start position and its direction "N", "E", "S" o "W". For instance “0 0 N” will set the initial dron position to the left bottom of the rectangle area oriented to the North.
 * Next line defines the dron movement action. The movements are codified by letters. “L” and “R” for turning left or right the drone 90º. “M” for moving forward one position the dron, for instance if the drone is moving towards north it will go from (x,y) to (x,y+1).
 * We can go on adding as many as pair instructions following the same specification explained in the points 3 and 4.
* Finally, after doing all the movements every drone will output its current position and direction in the same format as the start position was provided. 

## Development contributions
In case to change the requirements or need an evolution of the project there are the main points:
 * To create a new way to input instructions (API, WinForms, ...) create a new project with the new requirements and use the Exntension methods (in ForestDronController/Extensions) to parse into a correct format for then send the instructions to the DronController.
 * To create a new device (Now there are only the DronController) create a new class for the new device and inherit from the DeviceController which provide the minimum to manage the area, the start position and process the movements.
 The functions 'ProcessMovements' and 'MoveOneStepLocation' can be overriden to manage a different moving way.
