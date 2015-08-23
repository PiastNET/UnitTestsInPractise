using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using Shims;
using System;
namespace _04_Shims.Tests
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        [Test]
        public void Newly_Created_Invoice_Should_Have_IsNew_Flag_Set()
        {
            //Arrange
            var service = new InvoiceService();
            Invoice invoice;

            using (ShimsContext.Create())
            {
                var loggerShim = new Shims.Fakes.ShimLogger()
                {
                    LogString = (s) => { }
                };
                Shims.Fakes.ShimLogger.InstanceGet = () => loggerShim; // AllInstances.LogString = (l, s) => { };

                //Act
                invoice = service.CreateNewInvoice();
            }

            //Assert
            Assert.IsTrue(invoice.IsNew);
        }

        //[Test]
        //public void Newly_Created_Invoice_Should_Have_Current_Date()
        //{
        //    var service = new InvoiceService();
        //    Invoice invoice;

        //    using (ShimsContext.Create())
        //    {
        //        Shims.Fakes.ShimLogger.AllInstances.LogString = (l, s) => { };
        //        invoice = service.CreateNewInvoice();
        //    }

        //    //Assert
        //    Assert.AreEqual(DateTime.Now, invoice.DocumentDate);
        //}

        //[Test]
        //public void Newly_Created_Invoice_Should_Have_Current_Date_Shimed()
        //{
        //    var service = new InvoiceService();
        //    Invoice invoice;
        //    var date = new DateTime(2015, 6, 1);

        //    using (ShimsContext.Create())
        //    {
        //        Shims.Fakes.ShimLogger.AllInstances.LogString = (l, s) => { };
        //        System.Fakes.ShimDateTime.NowGet = () => date;
        //        //Act
        //        invoice = service.CreateNewInvoice();
        //    }

        //    //Assert
        //    Assert.AreEqual(date, invoice.DocumentDate);
        //}
    }
}
