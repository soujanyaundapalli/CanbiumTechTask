using FakeItEasy;
using MarsRover.Repository.Provider;
using MarsRover.Service;
using MarsRover.Service.Provider;
using MarsRover.Tests.MockObjects;
using MarsRovers.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests.ServiceTest
{
    public class MarsRoverServiceTest
    {
        /// <summary>
        /// invoker reference
        /// </summary>
        private readonly Invoker _invoker;

        /// <summary>
        /// IMarsRoverProblemSolutionService reference
        /// </summary>
        private readonly IMarsRoverService _marsRoverService;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MarsRoverServiceTest()
        {
            _invoker = A.Fake<Invoker>();
            _marsRoverService = new MarsRoverService();
        }

        /// <summary>
        /// test for MoveRoverSync method
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void MoveRoverSync_Test(bool isCoordinateNull)
        {
            //Arrange
            var maxPoints = MockData.MaxPoints;
            var currentLocation = MockData.CurrentLocation;
            var movement = MockData.Movement;
            var coordinates = MockData.Coordinates();
            if (!isCoordinateNull)
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => null);

            //Act
            var result = _marsRoverService.MoveRoverSync(maxPoints, currentLocation, movement, _invoker);

            //Assert
            if (!isCoordinateNull)
            {
                Assert.NotNull(result);
                Assert.AreEqual(coordinates.X, result.X);
                Assert.AreEqual(coordinates.Y, result.Y);
                Assert.AreEqual(coordinates.Dir, result.Dir);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
