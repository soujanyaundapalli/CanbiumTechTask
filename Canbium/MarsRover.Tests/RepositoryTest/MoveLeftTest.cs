using MarsRover.Repository.Command;
using MarsRover.Repository.Provider;
using MarsRover.Tests.MockObjects;
using MarsRovers.Data.Constants;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests.RepositoryTest
{
    public class MoveLeftTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MoveLeftTest()
        {
            _command = new MoveLeft();
        }

        /// <summary>
        /// test for Execute method
        /// </summary>
        /// <param name="directions"></param>
        [Test]
        [TestCase(Directions.N)]
        [TestCase(Directions.E)]
        [TestCase(Directions.S)]
        [TestCase(Directions.W)]
        public void Execute_Test(Directions directions)
        {
            //Arrange
            var coordinates = MockData.Coordinates();
            switch (directions)
            {
                case Directions.N:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    break;
            }

            //Act
            var result = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(coordinates, result);
        }
    }
}
