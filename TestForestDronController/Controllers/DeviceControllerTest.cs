using ForestDronController.Controllers;
using ForestDronController.Entities;
using ForestDronController.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestForestDronController.Controllers
{
    [TestClass]
    public class DeviceControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidLocationException))]
        public void ConstructorNullLocation_Exception()
        {
            Area area = new Area() { X = 5, Y = 6 }; 
            DeviceController ctr = new DeviceController(null, area);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAreaExeption))]
        public void ConstructorNullArea_Exception()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            DeviceController ctr = new DeviceController(location, null);
        }

        [TestMethod]
        public void Constructor_Location()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 6 };

            DeviceController ctr = new DeviceController(location, area);

            Assert.IsTrue(location.Equals(ctr.currentPosition));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfAreaException))]
        public void ConstructorLocationOutOfArea_Exception()
        {
            Location location = new Location() { X = 9, Y = 12, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 6 };

            DeviceController ctr = new DeviceController(location, area);
        }

        [TestMethod]
        public void UpdateStartLocation_Location()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 6 };
            Location newLocation = new Location() { X = 3, Y = 4, Direction = Direction.North};

            DeviceController ctr = new DeviceController(location, area);
            ctr.UpdateStartPosition(newLocation);


            Assert.IsTrue(newLocation.Equals(ctr.currentPosition));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfAreaException))]
        public void UpdateStartLocationOutOfArea_Exception()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 6 };
            Location newLocation = new Location() { X =6, Y = 7, Direction = Direction.North };

            DeviceController ctr = new DeviceController(location, area);
            ctr.UpdateStartPosition(newLocation);
        }

        [TestMethod]
        public void ProcessMovementLocation_Location()
        {
            Location location = new Location() { X = 3, Y = 3, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 5 };
            List<Movement> list = new List<Movement>()
            {
                Movement.Left
            };
            Location locationExpected = new Location() { X = 3, Y = 3, Direction = Direction.North };
            
            DeviceController ctr = new DeviceController(location, area);
            ctr.ProcessMovements(list);


            Assert.IsTrue(locationExpected.Equals(ctr.currentPosition));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfAreaException))]
        public void ProcessMovementoutOfArea_Exception()
        {
            Location location = new Location() { X = 3, Y = 3, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 5 };
            List<Movement> list = new List<Movement>()
            {
                Movement.Forward,
                Movement.Forward,
                Movement.Forward,
            };
            
            DeviceController ctr = new DeviceController(location, area);
            ctr.ProcessMovements(list);
        }

        [TestMethod]
        public void ProcessMovementAndUpdateStart_Location()
        {
            Location location = new Location() { X = 3, Y = 3, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 5 };
            List<Movement> list = new List<Movement>()
            {
                Movement.Left
            };
            Location locationExpected = new Location() { X = 1, Y = 4, Direction = Direction.North };

            // First movements
            DeviceController ctr = new DeviceController(location, area);
            ctr.ProcessMovements(list);

            //Second line of movements MMRMMRMRRM
            list = new List<Movement>()
            {
                Movement.Forward,
                Movement.Forward,
                Movement.Right,
                Movement.Forward,
                Movement.Forward,
                Movement.Right,
                Movement.Forward,
                Movement.Right,
                Movement.Right,
                Movement.Forward
            };
            ctr.UpdateStartPosition(new Location() { X = 3, Y = 3, Direction = Direction.East });
            ctr.ProcessMovements(list);

            //Third Line of movements 1 2 N - LMLMLMLM MLMLMLMLMM
            list = new List<Movement>()
            {
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Left,
                Movement.Forward,
                Movement.Forward
            };
            ctr.UpdateStartPosition(new Location() { X = 1, Y = 2, Direction = Direction.North });
            ctr.ProcessMovements(list);

            Assert.IsTrue(locationExpected.Equals(ctr.currentPosition));
        }
    }
}
