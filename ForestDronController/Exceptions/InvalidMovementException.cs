using System;

namespace ForestDronController.Exceptions
{
    public class InvalidMovementException : Exception
    {
        public InvalidMovementException(string movements)
            : base(String.Format("Invalid movements: {0}", movements))
        {
        }
    }
}
