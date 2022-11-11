using MarsRover.API;
using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests
{
    public class RoverTests
    {
        [Test]
        public void TestRoverCurrentPosition()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            Rover rover = new Rover(mockPosition.Object);

            Assert.AreEqual(1, rover.CurrentPosition.X);
            Assert.AreEqual(2, rover.CurrentPosition.Y);
            Assert.AreEqual(Direction.North, rover.CurrentPosition.Direction);
        }

        [Test]
        public void TestRoverMove()
        {
            Mock<IPosition> mockInitialPosition = new Mock<IPosition>();
            mockInitialPosition.Setup(x => x.X).Returns(1);
            mockInitialPosition.Setup(x => x.Y).Returns(2);
            mockInitialPosition.Setup(x => x.Direction).Returns(Direction.North);

            Mock<IPosition> mockNewPosition = new Mock<IPosition>();
            mockNewPosition.Setup(x => x.X).Returns(2);
            mockNewPosition.Setup(x => x.Y).Returns(3);
            mockNewPosition.Setup(x => x.Direction).Returns(Direction.West);

            Mock<IMoveCommand> mockMoveCommand = new Mock<IMoveCommand>();
            mockMoveCommand.Setup(x => x.Execute(mockInitialPosition.Object)).Returns(mockNewPosition.Object);

            Rover rover = new Rover(mockInitialPosition.Object);
            rover.Move(mockMoveCommand.Object);

            Assert.AreEqual(2, rover.CurrentPosition.X);
            Assert.AreEqual(3, rover.CurrentPosition.Y);
            Assert.AreEqual(Direction.West, rover.CurrentPosition.Direction);
        }
    }
}