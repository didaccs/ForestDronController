using ForestDronController.Entities;
using System;

namespace ForestDronController.Exceptions
{
    public class OutOfAreaException: Exception
    {
        public OutOfAreaException(Location location)
           : base(String.Format("Out of area on the direction {0} from location ({1},{2})", location.Direction, location.X, location.Y))
        {
        }
    }
}
