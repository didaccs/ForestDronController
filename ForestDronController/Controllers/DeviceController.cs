using ForestDronController.Entities;
using ForestDronController.Exceptions;
using ForestDronController.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestDronController.Controllers
{
    /// <summary>
    /// Class to manage the movement for a device
    /// </summary>
    public class DeviceController
    {
        public Location StartLocation { get; private set; }
        public Location CurrentPosition { get; private set; }
        public Area Area { get; private set; }

        /// <summary>
        /// Constructor with minimum parameters to process movements for a device.
        /// In case the start location is out of the area range an exception of OutOfAreaException is thrown.
        /// </summary>
        /// <param name="startLocation">The initial position for device</param>
        /// <param name="area">The area where the device can make movements</param>
        public DeviceController(Location startLocation, Area area)
        {
            this.StartLocation = startLocation ?? throw new InvalidLocationException("null");
            this.Area = area ?? throw new InvalidAreaExeption("null");
            if (IsLocationOutOfArea(startLocation))
            {
                throw new OutOfAreaException(startLocation);
            }
            CurrentPosition = startLocation;
        }

        /// <summary>
        /// Update the initial and current position for the device
        /// In case the start location is out of the area range an exception of OutOfAreaException is thrown.
        /// </summary>
        /// <param name="startPosition"></param>
        public void UpdateStartPosition(Location startPosition)
        {
            if (IsLocationOutOfArea(startPosition))
            {
                throw new OutOfAreaException(startPosition);
            }

            CurrentPosition = startPosition;
            StartLocation = startPosition;
        }

        /// <summary>
        /// Move the device according the movements param. 
        /// In case a movement is out of the area range an exception of OutOfAreaException is thrown.
        /// </summary>
        /// <param name="movements"></param>
        /// <returns></returns>
        public Location ProcessMovements(List<Movement> movements)
        {
            foreach (Movement move in movements)
            {
                UpdateCurrentPosition(move);
            }

            return CurrentPosition;
        }

        /// <summary>
        /// Update the current position direction or the location for a movement
        /// </summary>
        /// <param name="movement"></param>
        private void UpdateCurrentPosition(Movement movement)
        {
            CurrentPosition.Direction = CurrentPosition.Direction.ChangeDirection(movement);

            if (movement == Movement.Forward)
            {
                CurrentPosition = MoveOneStepLocation();
            }
        }

        /// <summary>
        /// Update the location of the current position
        /// </summary>
        /// <returns></returns>
        private Location MoveOneStepLocation()
        {
            Location nextLocation = new Location(){
                X = CurrentPosition.X,
                Y = CurrentPosition.Y,
                Direction = CurrentPosition.Direction
            };

            switch (nextLocation.Direction)
            {
                case Direction.North:
                    nextLocation.Y += 1;
                    break;
                case Direction.East:
                    nextLocation.X += 1;
                    break;
                case Direction.South:
                    nextLocation.Y -= 1;
                    break;
                case Direction.West:
                    nextLocation.X -= 1;
                    break;
            }

            if (IsLocationOutOfArea(nextLocation))
            {
                throw new OutOfAreaException(nextLocation);
            }

            return nextLocation;
        }

        /// <summary>
        /// Return if the param location is outside of the area range
        /// </summary>
        /// <param name="nextLocation"></param>
        /// <returns></returns>
        private bool IsLocationOutOfArea(Location nextLocation)
        {
            return (nextLocation.X < 0 || nextLocation.Y < 0 || nextLocation.X >= Area.X || nextLocation.Y >= Area.Y);
        }
    }
}
