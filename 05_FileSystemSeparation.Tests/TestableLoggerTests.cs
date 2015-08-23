using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
namespace _05_FileSystemSeparation.Tests
{
    [TestFixture]
    public class TestableLoggerTests
    {
        [Test]
        public void Should_Reset_Counter_After_Logging_10_Messages()
        {
            //Arrange
            var logger = new TestableLogger(10, new MockFileSystem());

            //Act
            foreach (var n in Enumerable.Range(1, 10))
            {
                logger.Log("Should_Reset_Counter_After_Logging_10_Messages");
            }

            //Assert
            Assert.AreEqual(0, logger.Counter);
        }
    }
}
