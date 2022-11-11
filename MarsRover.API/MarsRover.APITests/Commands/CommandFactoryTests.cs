using MarsRover.API.Commands;
using Moq;
using NUnit.Framework;

namespace MarsRover.APITests.Commands
{
    public class CommandFactoryTests
    {
        [Test]
        public void TestTryGetMoveForwardCommand()
        {
            Assert.IsTrue(CommandFactory.TryGetCommand('M', out IMoveCommand moveCommand));
            Assert.IsInstanceOf<ForwardCommand>(moveCommand);
        }

        [Test]
        public void TestTryGetRotateLeftCommand()
        {
            Assert.IsTrue(CommandFactory.TryGetCommand('L', out IMoveCommand moveCommand));
            Assert.IsInstanceOf<LeftCommand>(moveCommand);
        }

        [Test]
        public void TestTryGetRotateRightCommand()
        {
            Assert.IsTrue(CommandFactory.TryGetCommand('R', out IMoveCommand moveCommand));
            Assert.IsInstanceOf<RightCommand>(moveCommand);
        }

        [Test]
        public void TestTryGetInvalidCommand()
        {
            Assert.IsFalse(CommandFactory.TryGetCommand('Z', out IMoveCommand moveCommand));
            Assert.IsNull(moveCommand);
        }
    }
}