using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Linq;

namespace ForestDronController.Extensions
{
    public static class AreaExtension
    {
        public static String ToStringArea(this Area area)
        {
            return String.Format("({0},{1})", area.X, area.Y);
        }

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
