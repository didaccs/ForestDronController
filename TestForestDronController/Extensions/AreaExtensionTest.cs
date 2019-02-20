using ForestDronController.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForestDronController.Extensions;
using ForestDronController.Exceptions;

namespace TestForestDronController
{
    [TestClass]
    public class AreaExtensionTest
    {
        [TestMethod]
        public void AreaToString_String()
        {
            Area area = new Area() { X = 2, Y = 5 };
            const string expected = "(2,5)";

            string result = area.ToStringArea();

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StringToArea_Area()
        {
            string areaString = "2 5";
            Area expected = new Area() { X = 2, Y = 5 };

            Area result = areaString.ParseArea();

            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAreaExeption))]
        public void StringSymbolsToArea_InvalidException() 
        {
            string areaString = "(2,5)";

            Area result = areaString.ParseArea();            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAreaExeption))]
        public void StringNullToArea_InvalidException()
        {
            string areaString = string.Empty;
            
            Area result = areaString.ParseArea();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAreaExeption))]
        public void StringZeroToArea_InvalidException()
        {
            string areaString ="0 0";

            Area result = areaString.ParseArea();
        }
    }
}
