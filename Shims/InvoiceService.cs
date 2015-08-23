using System;

namespace Shims
{
    public class InvoiceService
    {
        public IInvoiceRepository InvoiceRepository { get; set; }

        public virtual Invoice CreateNewInvoice()
        {
            var invoice = new Invoice();

            invoice.DocumentNumber = String.Empty;
            invoice.DocumentDate = DateTime.Now;
            invoice.TotalValue = 0m;
            invoice.IsDirty = false;
            invoice.IsNew = true;
            //Some other complicated business logic here

            Logger.Instance.Log("New Invoice created");

            return invoice;
        }

        public virtual void SaveInvoice(Invoice invoice)
        {
            //Validation logic here
            //Other business logic here

            if (invoice.IsNew)
            {
                var number = InvoiceRepository.InsertInvoice(invoice);
                invoice.DocumentNumber = number;
                invoice.IsNew = false;
            }
            else if (invoice.IsDirty)
            //if(invoice.IsDirty)
            {
                InvoiceRepository.UpdateInvoice(invoice);
            }

            invoice.IsDirty = false;
            
            Logger.Instance.Log(String.Format("Invoice {0} saved", invoice.DocumentNumber));
        }

        public virtual void DeleteInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
