using MarsRover.API;
using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests.Commands
{
    public class MoveForwardCommandTests
    {
        [Test]
        public void TestMoveForwardCommandNorth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            var moveCommand = new ForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(3, newPosition.Y);
            Assert.AreEqual(Direction.North, newPosition.Direction);
        }

        [Test]
        public void TestMoveForwardCommandEast()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.East);

            var moveCommand = new ForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.AreEqual(2, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.East, newPosition.Direction);
        }

        [Test]
        public void TestMoveForwardCommandWest()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.West);

            var moveCommand = new ForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.AreEqual(0, newPosition.X);
            Assert.AreEqual(2, newPosition.Y);
            Assert.AreEqual(Direction.West, newPosition.Direction);
        }

        [Test]
        public void TestMoveForwardCommandSouth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.South);

            var moveCommand = new ForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.AreEqual(1, newPosition.X);
            Assert.AreEqual(1, newPosition.Y);
            Assert.AreEqual(Direction.South, newPosition.Direction);
        }
    }
}