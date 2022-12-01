using System.ComponentModel.DataAnnotations;

namespace BL;

public class InDetailsDTO
{
    #region Class Properties
    public string? Item { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public double TotalAmount { get; set; }
    #endregion
}
