using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Invoice
{
    #region Costructors
    public Invoice()
    {
        this.InvoiceDetails = new HashSet<InvoiceDetails>();
    }
    #endregion

    #region Class Properties

    [Key]
    public string? InvoiceId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime DateTime { get; set; }
    public int ItemsCount { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<InvoiceDetails> InvoiceDetails { get; set; }

    #endregion
}
