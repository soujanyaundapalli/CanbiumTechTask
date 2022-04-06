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
    public class MoveForwardTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// max coordinates
        /// </summary>
        private readonly List<int> _maxLst;

        /// <summary>
        /// constructor for instantiating references
        /// </summary>
        public MoveForwardTest()
        {
            _maxLst = MockData.MaxLst;
            _command = new MoveForward(_maxLst);
        }

        /// <summary>
        /// test for execute
        /// </summary>
        /// <param name="directions"></param>
        [Test]
        [TestCase(Directions.N)]
        [TestCase(Directions.E)]
        [TestCase(Directions.W)]
        [TestCase(Directions.S)]
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

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    break;
            }

            //Act
            var result = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(coordinates, result);
        }

        /// <summary>
        /// test for Execute failure
        /// </summary>
        /// <param name="isYExceed"></param>
        /// <param name="isXExceed"></param>
        /// <param name="isYLess"></param>
        /// <param name="isXLess"></param>
        [Test]
        [TestCase(true, false, false, false)]
        [TestCase(false, true, false, false)]
        [TestCase(false, false, true, false)]
        [TestCase(false, false, false, true)]
        [TestCase(true, true, false, false)]
        [TestCase(true, false, false, true)]
        [TestCase(false, true, true, false)]
        [TestCase(false, false, true, true)]
        public void ExecuteTest_Failure(bool isYExceed, bool isXExceed, bool isYLess, bool isXLess)
        {
            //Arrange
            var coordinates = MockData.Coordinates();
            if (isYExceed)
            {
                coordinates.Y = 6;
                coordinates.Dir = Directions.N;
            }
            if (isXExceed)
            {
                coordinates.X = 6;
                coordinates.Dir = Directions.E;
            }
            if (isYLess)
            {
                coordinates.Y = 0;
                coordinates.Dir = Directions.S;
            }
            if (isXLess)
            {
                coordinates.X = 0;
                coordinates.Dir = Directions.W;
            }

            //Act
            var result = _command.Execute(coordinates);

            //Assert
            Assert.Null(result);
        }
    }
}
