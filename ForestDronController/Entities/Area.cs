using System;

namespace ForestDronController.Entities
{
    public class Area: IEquatable<Area>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Area other)
        {
            if (other == null)
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y);
        }
    }
}
