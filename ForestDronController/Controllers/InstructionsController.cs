using ForestDronController.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestDronController.Controllers
{
    public class InstructionsController
    {
        public Location StartLocation { get; private set; }
        public Location CurrentPosition { get; private set; }

        public InstructionsController(Location startLocation)
        {
            this.StartLocation = startLocation;

        }

        public Location ProcessMovements(Movement[] movements)
        {
            return null;
        }
    }
}
