using System;

namespace ForestDronController.Exceptions
{
    public class InvalidAreaExeption: Exception
    {
        public InvalidAreaExeption(string area)
            : base(String.Format("Invalid area: {0}", area))
        {
        }
    }
}
