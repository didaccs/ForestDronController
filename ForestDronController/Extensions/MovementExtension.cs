using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForestDronController.Extensions
{
    /// <summary>
    /// Extension class for Parse Movement object
    /// </summary>
    public static class MovementExtension
    {

        /// <summary>
        /// Parse string to list of Movements. 
        /// In case that the string is not correct throw an InvalidMovementException
        /// </summary>
        /// <param name="movements"></param>
        /// <returns></returns>
        public static List<Movement> ParseMovements(this string movements)
        {
            // Check string length
            if (String.IsNullOrEmpty(movements) || movements.ToCharArray().Count() == 0)
            {
                throw new InvalidMovementException(movements);
            }

            List<Movement> resultMovements = new List<Movement>();

            //Check character value
            foreach (char movement in movements)
            {

                if (!Enum.IsDefined(typeof(Movement), (int)movement))                
                {
                    throw new InvalidMovementException(movements);
                }

                resultMovements.Add((Movement)movement);
            }

            return resultMovements;
        }
    }
}
