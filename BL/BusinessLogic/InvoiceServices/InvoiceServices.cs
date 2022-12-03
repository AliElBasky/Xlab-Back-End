using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BL;

public class InvoiceServices : IInvoiceService
{
    #region Dependency Injection
    private readonly IMapper _mapper;
    private readonly SalesContext _context;

    public InvoiceServices(SalesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region Get Invoice
    public async Task<InvoiceDTO> GetInvoiceAsync(string id)
    {
        try
        {
            var invoice = await GetInvoiceDetailsAsync(id);

            var readInvoice = _mapper.Map<InvoiceDTO>(invoice);

            return readInvoice;
        }
        catch (Exception)
        {
            return null;
        }        
    }
    #endregion

    #region Add Invoice
    public async Task<InvoiceDTO> AddInvoiceAsync(InvoiceDTO model)
    {
        try
        {
            var dbInvoice = _mapper.Map<Invoice>(model);

            await _context.Invoice.AddAsync(dbInvoice);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {

            return null;
        }
    }
    #endregion

    #region Update Invoice
    public async Task<InvoiceDTO> UpdateInvoiceAsync(InvoiceDTO model, string id)
    {
        try
        {
            var invoice = await GetInvoiceDetailsAsync(id);

            var newInvoice = _mapper.Map<Invoice>(model);

            invoice.InvoiceId = newInvoice.InvoiceId;
            invoice.CustomerName = newInvoice.CustomerName;
            invoice.DateTime = newInvoice.DateTime;
            invoice.ItemsCount = newInvoice.ItemsCount;
            invoice.TotalAmount = newInvoice.TotalAmount;
            invoice.InvoiceDetails = newInvoice.InvoiceDetails;

            _context.Update(invoice);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region Delete Invoice
    public async Task<bool> DeleteInvoiceAsync(string id)
    {
        try
        {
            var invoice = await GetInvoiceDetailsAsync(id);

            _context.Invoice_Details.RemoveRange(invoice.InvoiceDetails);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #region Helper Methods
    public async Task<Invoice?> GetInvoiceByIdAsync(string id)
    {
        var result = await _context.Invoice.FirstOrDefaultAsync(i => i.InvoiceId == id);
        return result;
    }

    public async Task<Invoice?> GetInvoiceDetailsAsync(string id)
    {
        var result = await _context.Invoice.Where(i => i.InvoiceId == id).Include(d => d.InvoiceDetails).FirstOrDefaultAsync();
        return result;
    }
    #endregion
}
