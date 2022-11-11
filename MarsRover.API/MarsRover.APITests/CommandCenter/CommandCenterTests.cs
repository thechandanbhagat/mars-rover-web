using MarsRover.API;
using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests
{
    public class CommandCenterTests
    {
        private Mock<IRover> _mockRover;
        private Mock<ISurface> _mockSurface;

        [SetUp]
        public void TestSetup()
        {
            Mock<IPosition> mockInitialPosition = new Mock<IPosition>();
            mockInitialPosition.Setup(x => x.X).Returns(1);
            mockInitialPosition.Setup(x => x.Y).Returns(2);
            mockInitialPosition.Setup(x => x.Direction).Returns(Direction.North);

            _mockRover = new Mock<IRover>();
            _mockRover.Setup(x => x.CurrentPosition).Returns(mockInitialPosition.Object);

            _mockSurface = new Mock<ISurface>();
            _mockSurface.Setup(x => x.Width).Returns(5);
            _mockSurface.Setup(x => x.Length).Returns(5);
        }

        [Test]
        public void TestCommandCenterExecuteCommandA()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands(new string[] { "MMM" });
            _mockRover.Verify(x => x.Move(It.IsAny<ForwardCommand>()), Times.Exactly(3));
        }

        [Test]
        public void TestCommandCenterExecuteCommandR()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands(new string[] { "RRR" });
            _mockRover.Verify(x => x.Move(It.IsAny<RightCommand>()), Times.Exactly(3));
        }

        [Test]
        public void TestCommandCenterExecuteCommandL()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands(new string[] { "LLL" });
            _mockRover.Verify(x => x.Move(It.IsAny<LeftCommand>()), Times.Exactly(3));
        }

        [Test]
        public void TestCommandCenterExecuteMultipleCommands()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands(new string[] { "MLR" });
            _mockRover.Verify(x => x.Move(It.IsAny<ForwardCommand>()), Times.Once);
            _mockRover.Verify(x => x.Move(It.IsAny<LeftCommand>()), Times.Once);
            _mockRover.Verify(x => x.Move(It.IsAny<RightCommand>()), Times.Once);
        }

        //[Test]
        //public void TestCommandCenterGetStatus()
        //{
        //    _mockSurface.Setup(x => x.IsPointInside(_mockRover.Object.CurrentPosition)).Returns(true);
        //    ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
        //    Assert.AreEqual("True, N, (1,2)", commandCenter.GetStatus());
        //}

        //[Test]
        //public void TestCommandCenterMoveOutsideSurfaceGetStatus()
        //{
        //    _mockSurface.Setup(x => x.IsPointInside(_mockRover.Object.CurrentPosition)).Returns(false);
        //    ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
        //    Assert.AreEqual("False, N, (1,2)", commandCenter.GetStatus());
        //}
    }
}