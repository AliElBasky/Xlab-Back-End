using System.ComponentModel.DataAnnotations;

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
    [Required]
    public int ItemsCount { get; set; }
    [Required]
    public double TotalAmount { get; set; }
    [Required]
    public ICollection<InDetailsDTO> InvoiceDetails { get; set; }
    #endregion
}
