using ForestDronController.Entities;
using ForestDronController.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestDronController.Controllers
{
    public class DronController
    {
        public Location _startLocation { get; private set; }
        public Location _currentPosition { get; private set; }
        public Area _area { get; set; }

        public DronController(Location startLocation, Area area)
        {
            _startLocation = startLocation ?? throw new InvalidLocationException("null");
            _area = area ?? throw new InvalidAreaExeption("null");
        }

        public Location ProcessMovements(List<Movement> movements)
        {
            return null;
        }
    }
}
