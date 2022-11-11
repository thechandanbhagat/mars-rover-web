using MarsRover.API;
using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests.Commands
{
    public class RotateLeftCommandTests
    {
        [Test]
        public void RotateLeftCommandNorth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            var rotateCommand = new LeftCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.West, newPosition.Direction);
        }

        [Test]
        public void RotateLeftCommandEast()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.East);

            var rotateCommand = new LeftCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.North, newPosition.Direction);
        }

        [Test]
        public void RotateLeftCommandSouth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.South);

            var rotateCommand = new LeftCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.East, newPosition.Direction);
        }

        [Test]
        public void RotateLeftCommandWest()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.West);

            var rotateCommand = new LeftCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.South, newPosition.Direction);
        }
    }
}