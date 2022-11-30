namespace BL;

public class InvoiceDTO
{
    #region Constructors
    public InvoiceDTO()
    {
        this.InvoiceDetails = new HashSet<InDetailsDTO>();
    }
    #endregion

    #region Class Properties
    public string? InvoiceId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime DateTime { get; set; }
    public int ItemsCount { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<InDetailsDTO> InvoiceDetails { get; set; }
    #endregion
}
