using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Linq;

namespace ForestDronController.Extensions
{
    /// <summary>
    /// Extension class for Parse Location object
    /// </summary>
    public static class LocationExtension
    {
        /// <summary>
        /// Parse Location to string with format 0 0 E
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static String ToStringLocation(this Location location)
        {
            if (location == null)
            {
                return String.Empty;
            }
            else
            {
                return String.Format("{0} {1} {2}", location.X, location.Y, (char)location.Direction);
            }
        }

        /// <summary>
        /// Parse string to Location. 
        /// In case that the string is not correct throw an InvalidLocationException
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
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

            //Check character value
            if (!Direction.TryParse(typeof(Direction), ((int)locationChars[4]).ToString(), out object dir))
            {
                throw new InvalidLocationException(location);
            }

            double xLocation = Char.GetNumericValue(locationChars[0]);
            double yLocation = Char.GetNumericValue(locationChars[2]);

            //check number values
            if (xLocation <= 0 || yLocation <= 0 || xLocation >= int.MaxValue || yLocation >= int.MaxValue || dir == null)
            {
                throw new InvalidLocationException(location);
            }

            return new Location { X = (int)xLocation, Y = (int)yLocation, Direction = (Direction)dir };
        }
    }
}
