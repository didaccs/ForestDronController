using ForestDronController.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestDronController.Extensions
{
    public static class DirectionExtension
    {
        /// <summary>
        /// Return direction with the movement parameter apllied
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public static Direction ChangeDirection(this Direction direction,  Movement movement)
        {
            if (movement == Movement.Forward)
            {
                return direction;
            }
            else
            {
                Direction newDirection = direction;
                switch (direction)
                {
                    case Direction.North:
                        newDirection = movement == Movement.Right ? Direction.East : Direction.West;
                        break;
                    case Direction.East:
                        newDirection = movement == Movement.Right ? Direction.South : Direction.North;
                        break;
                    case Direction.South:
                        newDirection = movement == Movement.Right ? Direction.West : Direction.East;
                        break;
                    case Direction.West:
                        newDirection = movement == Movement.Right ? Direction.North : Direction.South;
                        break;
                }
                return newDirection;
            }
        }
    }
}
