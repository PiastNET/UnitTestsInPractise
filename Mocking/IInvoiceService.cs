using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mocking
{
    public interface IInvoiceService
    {
        Invoice CreateNewInvoice();
        void SaveInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
    }
}
