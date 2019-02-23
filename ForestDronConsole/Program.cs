using ForestDronConsole.Properties;
using ForestDronController.Extensions;
using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Collections.Generic;
using ForestDronController.Controllers;
using System.Linq;

namespace ForestDronConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    UserInstructionsInput();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }

                Console.WriteLine();
                Console.WriteLine("Press the Escape (Esc) key to quit or any other to restart.");
                ConsoleKeyInfo cki = Console.ReadKey();
                exit = cki.Key == ConsoleKey.Escape;
            }

        }
        
        private static void UserInstructionsInput()
        {
            Console.Clear();
            Console.WriteLine(Resources.Instructions);
            List<string> lines = GetStringInstructions();

            if (lines.Count > 0)
            {
                RunInstructions(lines);
            }
        }

        private static List<string> GetStringInstructions()
        {
            Boolean runCommands = false;
            List<String> lines = new List<string>();

            while (!runCommands)
            {
                string str = Console.ReadLine();
                if (String.IsNullOrEmpty(str))
                {
                    runCommands = true;
                }
                else
                {
                    lines.Add(str);
                }
            }

            return lines;
        }

        private static void RunInstructions(List<string> lines)
        {
            List<Instruction> listInstructions = new List<Instruction>();
            Area area = lines.First().ParseArea();
            for (int idLine = 1; idLine < lines.Count; idLine = idLine + 2)
            {
                Location location = lines[idLine].ParseLocation();
                List<Movement> movements = lines[idLine + 1].ParseMovements();

                listInstructions.Add(new Instruction() { StartPosition = location, Movements = movements });
            }

            Console.WriteLine("Dron positions:");

            foreach (Instruction instr in listInstructions)
            {
                DronController dronCtr = new DronController(area);
                dronCtr.ManageInstructions(instr);
                Console.WriteLine(dronCtr.CurrentPosition.ToStringLocation());
            }
        }
    }
}
