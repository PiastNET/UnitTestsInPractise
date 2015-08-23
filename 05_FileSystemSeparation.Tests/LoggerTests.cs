
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using NUnit.Framework;
using System.IO;
using System.IO.Fakes;
using System.Linq;
namespace _05_FileSystemSeparation.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        #region Without separation
        //[Test]
        //public void Should_Reset_Counter_After_Logging_10_Messages_Without_Shim()
        //{
        //    //Arrange
        //    var logger = new Logger(10);

        //    //Act
        //    foreach (var n in Enumerable.Range(1, 10))
        //    {
        //        logger.Log("Should_Reset_Counter_After_Logging_10_Messages");
        //    }

        //    //Assert
        //    Assert.AreEqual(0, logger.Counter);
        //}

        //[Test]
        //public void Should_Increment_Counter_After_Logging_Message()
        //{
        //    var logger = new Logger(100);
        //    var counter = logger.Counter;

        //    logger.Log("Should_Increment_Counter_After_Logging_Message");

        //    Assert.AreEqual(counter+1, logger.Counter);
        //}
        #endregion

        #region Shims
        [Test]
        public void Should_Reset_Counter_After_Logging_10_Messages()
        {
            //Arrange
            var logger = new Logger(10);

            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.AppendTextString = (s) => StreamWriter.Null;
                //Act
                foreach (var n in Enumerable.Range(1, 10))
                {
                    logger.Log("Should_Reset_Counter_After_Logging_10_Messages");
                }
            }
            //Assert
            Assert.AreEqual(0, logger.Counter);
        }

        [Test]
        public void Should_Increment_Counter_After_Logging_Message()
        {
            var logger = new Logger(100);
            var counter = logger.Counter;
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.AppendTextString = (s) => StreamWriter.Null;
                logger.Log("Should_Increment_Counter_After_Logging_Message");
            }

            Assert.AreEqual(counter + 1, logger.Counter);
        }
        #endregion
    }
}
