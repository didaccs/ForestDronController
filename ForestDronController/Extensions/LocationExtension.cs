using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ForestDronController.Extensions
{
    public static class LocationExtension
    {
        public static String ToStringLocation(this Location location)
        {
            return String.Format("{0} {1} {2}", location.X, location.Y, (char)location.Direction);
        }

        public static Location ParseLocation(this string location)
        {
            // Check string length
            if (String.IsNullOrEmpty(location) || location.ToCharArray().Count() != 5)
            {
                throw new InvalidLocationException(location);
            }

            char[] locationChars = location.ToCharArray();

            //check format number + space + number + space + [N,E,S,W]
            if (!Char.IsNumber(locationChars[0]) || !Char.IsWhiteSpace(locationChars[1]) || !Char.IsNumber(locationChars[2])
                || !Char.IsWhiteSpace(locationChars[3]) || !Char.IsLetter(locationChars[4]))
            {
                throw new InvalidLocationException(location);
            }

            double xLocation = Char.GetNumericValue(locationChars[0]);
            double yLocation = Char.GetNumericValue(locationChars[2]);
            Enum.TryParse(typeof(Direction), locationChars[4].ToString(), out object dir);

            //check number values
            if (xLocation <= 0 || yLocation <= 0 || xLocation >= int.MaxValue || yLocation >= int.MaxValue || dir == null)
            {
                throw new InvalidLocationException(location);
            }

            return new Location { X = (int)xLocation, Y = (int)yLocation, Direction = (Direction)dir };
        }
    }
}
