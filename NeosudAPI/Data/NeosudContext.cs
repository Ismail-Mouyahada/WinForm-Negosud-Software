using Microsoft.EntityFrameworkCore;

namespace NeosudAPI.Data;

public class NeosudContext : DbContext
{
    public NeosudContext(DbContextOptions<NeosudContext> options)
        : base(options)
    {
    }

    public DbSet<NeosudContext> Bottle { get; set; } = null!;
    public DbSet<NeosudContext> Store { get; set; } = null!;
    public DbSet<NeosudContext> Category { get; set; } = null!;
    public DbSet<NeosudContext> City { get; set; } = null!;
    public DbSet<NeosudContext> Country { get; set; } = null!;
    public DbSet<NeosudContext> Customer { get; set; } = null!;
    public DbSet<NeosudContext> CustomerOrder { get; set; } = null!;
    public DbSet<NeosudContext> CustomerOrderItem { get; set; } = null!;
    public DbSet<NeosudContext> Employee { get; set; } = null!;
    public DbSet<NeosudContext> Inventory { get; set; } = null!;
    public DbSet<NeosudContext> Invoice { get; set; } = null!;
    public DbSet<NeosudContext> InvoiceItem { get; set; } = null!;
    public DbSet<NeosudContext> Order { get; set; } = null!;
    public DbSet<NeosudContext> OrderItem { get; set; } = null!;
    public DbSet<NeosudContext> Producer { get; set; } = null!;
    public DbSet<NeosudContext> Region { get; set; } = null!;
    public DbSet<NeosudContext> Supplier { get; set; } = null!;

}