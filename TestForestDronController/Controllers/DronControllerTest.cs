using ForestDronController.Controllers;
using ForestDronController.Entities;
using ForestDronController.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestForestDronController.Controllers
{
    [TestClass]
    public class DronControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidLocationException))]
        public void ConstructorNullLocation_Exception()
        {
            Area area = new Area() { X = 5, Y = 6 }; 
            DronController ctr = new DronController(null, area);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAreaExeption))]
        public void ConstructorNullArea_Exception()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            DronController ctr = new DronController(location, null);
        }

        [TestMethod]
        public void ConstructorLocation_Location()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            Area area = new Area() { X = 5, Y = 6 };

            DronController ctr = new DronController(location, area);

            Assert.IsTrue(location.Equals(ctr._startLocation));
        }
    }
}
