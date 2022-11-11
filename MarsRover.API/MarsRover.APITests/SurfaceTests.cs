using MarsRover.API;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests
{
    public class SurfaceTests
    {
        [Test]
        public void TestSurfacePointInside()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            ISurface surface = new Surface(5, 5);
            Assert.IsTrue(surface.IsPointInside(mockPosition.Object));
        }

        [Test]
        public void TestSurfacePointInsideRightEdge()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(5);
            mockPosition.Setup(x => x.Y).Returns(5);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            ISurface surface = new Surface(5, 5);
            Assert.IsTrue(surface.IsPointInside(mockPosition.Object));
        }

        [Test]
        public void TestSurfacePointInsideLeftEdge()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(0);
            mockPosition.Setup(x => x.Y).Returns(0);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            ISurface surface = new Surface(5, 5);
            Assert.IsTrue(surface.IsPointInside(mockPosition.Object));
        }

        [Test]
        public void TestSurfacePointOutside()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(6);
            mockPosition.Setup(x => x.Y).Returns(3);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            ISurface surface = new Surface(5, 5);
            Assert.IsFalse(surface.IsPointInside(mockPosition.Object));
        }

        [Test]
        public void TestSurfacePointOutsideNegative()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(-1);
            mockPosition.Setup(x => x.Y).Returns(3);
            mockPosition.Setup(x => x.Direction).Returns(Direction.North);

            ISurface surface = new Surface(5, 5);
            Assert.IsFalse(surface.IsPointInside(mockPosition.Object));
        }
    }
}