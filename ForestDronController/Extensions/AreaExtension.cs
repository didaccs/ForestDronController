using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Linq;

namespace ForestDronController.Extensions
{
    /// <summary>
    /// Extension class for Parse Area object
    /// </summary>
    public static class AreaExtension
    {
        /// <summary>
        /// Parse Area to string with format 0 0
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static String ToStringArea(this Area area)
        {
            if (area ==  null)
            {
                return String.Empty;
            }
            else
            {
                return String.Format("{0}x{1}", area.X, area.Y);
            }
        }

        /// <summary>
        /// Parse string to Area. 
        /// In case that the string is not correct throw an InvalidAreaException
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static Area ParseArea(this string area)
        {
            // Check string length
            if (String.IsNullOrEmpty(area) || area.ToCharArray().Count() != 3)
            {
                throw new InvalidAreaExeption(area);
            }

            char[] areaChars = area.ToCharArray();

            //check format number + space + number
            if (!Char.IsNumber(areaChars[0]) || !Char.IsWhiteSpace(areaChars[1]) || !Char.IsNumber(areaChars[2]))
            {
                throw new InvalidAreaExeption(area);
            }

            double xLocation = Char.GetNumericValue(areaChars[0]);
            double yLocation = Char.GetNumericValue(areaChars[2]);

            //check number values
            if (xLocation <= 0 || yLocation <= 0 || xLocation >= int.MaxValue || yLocation >= int.MaxValue)
            {
                throw new InvalidAreaExeption(area);
            }

            return new Area { X =  (int)xLocation, Y = (int)yLocation};
        }
    }
}
