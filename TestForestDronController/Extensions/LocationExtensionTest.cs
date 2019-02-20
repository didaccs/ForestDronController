using ForestDronController.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForestDronController.Extensions;
using ForestDronController.Exceptions;

namespace TestForestDronController.Extensions
{
    [TestClass]
    public class LocationExtensionTest
    {
        [TestMethod]
        public void LocationToString_String()
        {
            Location location = new Location() { X = 1, Y = 2, Direction = Direction.East };
            const string expected = "1 2 E";

            string result = location.ToStringLocation();

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringToLocation_Location()
        {
            string locationString = "1 2 E";
            Location expected = new Location() { X = 1, Y = 2,  Direction = Direction.East };

            Location result = locationString.ParseLocation();

            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLocationException))]
        public void StringSymbolsToLocation_InvalidException()
        {
            string locationString = "1x2_E";

            Location result = locationString.ParseLocation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLocationException))]
        public void StringNullToLocation_InvalidException()
        {
            string locationString = string.Empty;

            Location result = locationString.ParseLocation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLocationException))]
        public void StringZeroToLocation_InvalidException()
        {
            string locationString = "0 0";

            Location result = locationString.ParseLocation();
        }
    }
}
