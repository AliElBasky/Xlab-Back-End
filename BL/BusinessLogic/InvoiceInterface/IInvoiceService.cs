namespace BL;

public interface IInvoiceService
{
    Task<InvoiceDTO> GetInvoiceAsync(string id);
    Task<InvoiceDTO> AddInvoiceAsync(InvoiceDTO model);
    Task<InvoiceDTO> UpdateInvoiceAsync(InvoiceDTO model, string id);
    Task<bool> DeleteInvoiceAsync(string id);
}
