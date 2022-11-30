using Microsoft.EntityFrameworkCore;

namespace DAL;

public class SalesContext : DbContext
{
    #region Constructor
    public SalesContext(DbContextOptions<SalesContext> options) : base(options)
    {

    }
    #endregion

    #region Data Sets
    public DbSet<Invoice>? Invoice { get; set; }
    public DbSet<InvoiceDetails>? Invoice_Details { get; set; }

    #endregion

    #region Fluent Api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .HasIndex(i => i.InvoiceId)
            .IsUnique();
    }
    #endregion
}
