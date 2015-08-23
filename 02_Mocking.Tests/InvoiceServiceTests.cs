using Mocking;
using NSubstitute;
using NUnit.Framework;

namespace _02_Mocking.Tests
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        [Test]
        public void Newly_Created_Invoice_Should_Have_IsNew_Flag_Set()
        {
            //Arrange
            var service = new InvoiceService();
            var invoice = service.CreateNewInvoice();
            Assert.IsTrue(invoice.IsNew);
        }

        [Test]
        public void Newly_Created_Invoice_Should_Have_IsDirty_Flag_Unset()
        {
            //Arrange
            var service = new InvoiceService();

            var invoice = service.CreateNewInvoice();

            Assert.IsFalse(invoice.IsDirty);
        }

        [Test]
        public void Service_Should_Call_InsertInvoice_Repository_Method_For_New_Invoice()
        {
            //Arrange
            var service = new InvoiceService();
            var targetNumber = "FS/00005/2015";
            var invoice = new Invoice() { IsNew = true, IsDirty = false };

            var repository = Substitute.For<IInvoiceRepository>();
            repository.InsertInvoice(Arg.Any<Invoice>()).Returns(targetNumber);
            service.InvoiceRepository = repository;

            //Act
            service.SaveInvoice(invoice);

            //Assert
            repository.Received().InsertInvoice(invoice);
        }

        [Test]
        public void Service_Should_Not_Call_UpdateInvoice_Repostitory_Method_For_New_Invoice()
        {
            //Arrange
            var service = new InvoiceService();
            var invoice = new Invoice() { IsNew = true, IsDirty = true };
            var repository = Substitute.For<IInvoiceRepository>();
            service.InvoiceRepository = repository;

            //Act
            service.SaveInvoice(invoice);

            //Assert
            repository.DidNotReceive().UpdateInvoice(invoice);
        }
    }
}
