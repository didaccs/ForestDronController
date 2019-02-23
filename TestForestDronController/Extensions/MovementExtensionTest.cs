using ForestDronController.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForestDronController.Extensions;
using System.Collections.Generic;

namespace TestForestDronController.Extensions
{
    [TestClass]
    public class MovementExtensionTest
    {
        [TestMethod]
        public void StringToLocation_Location()
        {
            string movementsString = "MLMRM";
            List<Movement> expected = new List<Movement>() { Movement.Forward, Movement.Left, Movement.Forward, Movement.Right, Movement.Forward };

            List<Movement> result = movementsString.ParseMovements();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
