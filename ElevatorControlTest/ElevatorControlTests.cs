using ElevatorControl;
using ElevatorControl.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace ElevatorControlTest
{
    [TestClass]
    class ElevatorControlTests
    {
        [TestMethod]
        public void RequestFloorAddsFloorSuccess()
        {
            State state = new State();
            ElevatorController ec = new ElevatorController(state);
            IActionResult result = ec.RequestFloor(1);
            HttpStatusCode status = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            Assert.Equals(status, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetFloorsWithFloorsReturnsSuccess()
        {
            State state = new State();
            ElevatorController ec = new ElevatorController(state);
            ec.RequestFloor(1);
            IActionResult result = ec.GetFloors();
            HttpStatusCode status = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            Assert.Equals(status, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetFloorsWithoutFloorsReturnsNoContent()
        {
            State state = new State();
            ElevatorController ec = new ElevatorController(state);
            IActionResult result = ec.GetFloors();
            HttpStatusCode status = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            Assert.Equals(status, HttpStatusCode.NoContent);
        }

        [TestMethod]
        public void NextFloorReturnsSuccess()
        {
            State state = new State();
            ElevatorController ec = new ElevatorController(state);
            ec.RequestFloor(1);
            IActionResult result = ec.NextFloor();
            HttpStatusCode status = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            Assert.Equals(status, HttpStatusCode.OK);
        }

        [TestMethod]
        public void NextFloorReturnsNoContent()
        {
            State state = new State();
            ElevatorController ec = new ElevatorController(state);
            IActionResult result = ec.NextFloor();
            HttpStatusCode status = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            Assert.Equals(status, HttpStatusCode.OK);
        }
    }
}
