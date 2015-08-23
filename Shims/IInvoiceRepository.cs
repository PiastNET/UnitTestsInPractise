using System.Linq;

namespace Shims
{
    public interface IInvoiceRepository
    {
        IQueryable<Invoice> GetAllInvoices();
        string InsertInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        void DeleteInvoice(string documentNumber);
        void GetInvoiceByNumber(string documentNumber);
    }
}
