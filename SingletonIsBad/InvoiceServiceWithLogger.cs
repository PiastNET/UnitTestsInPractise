using Mocking;
using System;

namespace SingletonIsBad
{
    public class InvoiceServiceWithLogger: InvoiceService
    {
        //public Logger Logger { get; set; }

        public override Invoice CreateNewInvoice()
        {
            var invoice = base.CreateNewInvoice();
            Logger.Instance.Log("Created new invoice");
            //this.Logger.Log("Created new invoice");
            return invoice;
        }

        public override void SaveInvoice(Invoice invoice)
        {
            base.SaveInvoice(invoice);
            Logger.Instance.Log(String.Format("Invoice {0} saved", invoice.DocumentNumber));
            //this.Logger.Log(String.Format("Invoice {0} saved", invoice.DocumentNumber));
        }
    }
}
