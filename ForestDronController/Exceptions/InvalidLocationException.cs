using System;

namespace ForestDronController.Exceptions
{
    public class InvalidLocationException: Exception
    {
        public InvalidLocationException(string location)
            :base(String.Format("Invalid location: {0}", location))
        {
        }
    }
}
