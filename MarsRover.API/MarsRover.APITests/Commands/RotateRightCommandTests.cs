using MarsRover.API;
using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests.Commands
{
    public class RotateRightCommandTests
    {
        [Test]
        public void RotateRightCommandNorth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            var rotateCommand = new RightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.East, newPosition.Direction);
        }

        [Test]
        public void RotateRightCommandEast()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.East);

            var rotateCommand = new RightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.South, newPosition.Direction);
        }

        [Test]
        public void RotateRightCommandSouth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.South);

            var rotateCommand = new RightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.West, newPosition.Direction);
        }

        [Test]
        public void RotateRightCommandWest()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.West);

            var rotateCommand = new RightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.North, newPosition.Direction);
        }
    }
}