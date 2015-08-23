using NSubstitute;
using NUnit.Framework;
using SingletonIsBad;

namespace _03_SingletonIsBad.Tests
{
    [TestFixture]
    public class InvoiceServiceWithLoggerTests
    {
        [Test]
        public void Newly_Created_Invoice_Should_Have_IsNew_Flag_Set()
        {
            var service = new InvoiceServiceWithLogger();

            var invoice = service.CreateNewInvoice();

            Assert.IsTrue(invoice.IsNew);
        }

        //[Test]
        //public void Mocked_Newly_Created_Invoice_Should_Have_IsNew_Flag_Set()
        //{
        //    var service = new InvoiceServiceWithLogger();
        //    var logger = Substitute.For<Logger>();
        //    service.Logger = logger;

        //    var invoice = service.CreateNewInvoice();

        //    Assert.IsTrue(invoice.IsNew);
        //}
    }
}
