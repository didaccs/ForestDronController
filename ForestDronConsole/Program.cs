using ForestDronConsole.Properties;
using ForestDronController.Extensions;
using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Collections.Generic;
using ForestDronController.Controllers;

namespace ForestDronConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Resources.Instructions);
            Area area = GetArea();

            DronController dronCtr = new DronController(area);

            while (true)
            {
                Instruction instructions = GetInstructions();
                dronCtr.ManageInstructions(instructions);
                Console.WriteLine("Current position:" + dronCtr.CurrentPosition.ToStringLocation());
                Console.WriteLine("You can add new start position and more movements and press intro.");
                Console.WriteLine();
            }
        }

        private static Area GetArea()
        {
            Area area = null;
            try
            {
                string areaStr = Console.ReadLine();
                 area = areaStr.ParseArea();
            }
            catch (InvalidAreaExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Insert a valid area:");                
            }

            return area;
        }

        private static Instruction GetInstructions()
        {
            Location startLocation = null;
            List<Movement> movementsList = null;
            try
            {
                string startPositionStr = Console.ReadLine();
                startLocation = startPositionStr.ParseLocation();
            }
            catch (InvalidLocationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Insert a valid location:");
            }

            try
            {
                string movementsStr = Console.ReadLine();
                movementsList = movementsStr.ParseMovements();
            }
            catch (InvalidLocationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Insert valids movements:");
            }

            return new Instruction()
            {
                Movements = movementsList,
                StartPosition = startLocation
            };
        }
    }
}
