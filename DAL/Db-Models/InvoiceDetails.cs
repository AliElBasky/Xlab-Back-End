using System.ComponentModel.DataAnnotations;

namespace DAL;

public class InvoiceDetails
{
    #region Class Properties

    [Key]
    public int Id { get; set; }
    public string? Item { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public double TotalAmount { get; set; }

    #endregion
}
