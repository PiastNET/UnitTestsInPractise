using System;

namespace Mocking
{
    public class InvoiceService : IInvoiceService
    {
        public IInvoiceRepository InvoiceRepository { get; set; }

        public virtual Invoice CreateNewInvoice()
        {
            var invoice = new Invoice();
            
            invoice.DocumentNumber = String.Empty;
            invoice.TotalValue = 0m;
            invoice.IsDirty = false;
            invoice.IsNew = true;
            //Some other complicated business logic here

            return invoice;
        }

        public virtual void SaveInvoice(Invoice invoice)
        {
            //Validation logic here
            //Other business logic here

            if(invoice.IsNew)
            {
                var number = InvoiceRepository.InsertInvoice(invoice);
                invoice.DocumentNumber = number;
                invoice.IsNew = false;
            }
            else if(invoice.IsDirty)
            //if(invoice.IsDirty)
            {
                InvoiceRepository.UpdateInvoice(invoice);
            }

            invoice.IsDirty = false;
        }

        public virtual void DeleteInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
