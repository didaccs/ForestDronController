using System;

namespace ForestDronController.Entities
{
    public class Location: IEquatable<Location>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public bool Equals(Location other)
        {
            if (other == null)
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y) && (Direction == other.Direction);
        }
    }
}
