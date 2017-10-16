using System.Data.Entity;
using SportsStorePrism.Infrastucture.Entities;

namespace SportsStorePrism.Module.Services
{
  public class SportsStoreDbContext : DbContext
  {
    public SportsStoreDbContext() : base("SportsStoreConnection") { }

    public DbSet<Product> Products { get; set; }
  }
}
