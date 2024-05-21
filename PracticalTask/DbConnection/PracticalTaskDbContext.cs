using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;

namespace PracticalTask.DbConnection;

public class PracticalTaskDbContext : DbContext
{
    public PracticalTaskDbContext(DbContextOptions<PracticalTaskDbContext> options) : base(options)
    {

    }


    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<ProductUnit> ProductUnits { get; set; }
    public DbSet<Product> ProductsServices { get; set; }
    public DbSet<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }
    public DbSet<MeetingMinutesDetails> MeetingMinutesDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MeetingMinutesMaster>()
            .HasOne(m => m.CorporateCustomer).WithMany(x => x.MeetingMinutesMasters)
            .HasForeignKey(m => m.CorporateCustomerId);

        modelBuilder.Entity<MeetingMinutesMaster>()
            .HasOne(m => m.IndividualCustomer).WithMany(x => x.MeetingMinutesMasters)
            .HasForeignKey(m => m.IndividualCustomerId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductUnit).WithMany(x => x.ProductServices)
            .HasForeignKey(p => p.UnitId);

        modelBuilder.Entity<MeetingMinutesDetails>()
            .HasOne(d => d.MeetingMinutesMaster).WithMany(x => x.MeetingMinutesDetails)
            .HasForeignKey(d => d.MeetingId);

        modelBuilder.Entity<MeetingMinutesDetails>()
            .HasOne(d => d.Product).WithMany(x => x.MeetingMinutesDetails)
            .HasForeignKey(d => d.ProductId);
    }


}
