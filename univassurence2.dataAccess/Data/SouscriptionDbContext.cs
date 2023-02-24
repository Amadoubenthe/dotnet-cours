using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using univassurence2.dataAccess.models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace univassurence2.dataAccess.Data
{
  public class SouscriptionDbContext : DbContext
  {
    public virtual DbSet<Person> Person { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<Commercial> Commercial { get; set; }
    public virtual DbSet<Subscription> Subscription { get; set; }
    public SouscriptionDbContext()
    {

    }

    public SouscriptionDbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      if (!options.IsConfigured)
      {
        options.UseSqlServer("Server=DESKTOP-U9KP4C1;Database=univ_db1;Trusted_Connection=True;Encrypt=False;User Id=sa;Password=1234");
      }
    }

    protected override void OnModelCreating(ModelBuilder ab)
    {
      ab.Entity<Product>(entite =>
      {
        entite.HasKey(proprietes => proprietes.ProductId);
      });

      ab.Entity<Commercial>(entite =>
      {
        entite.HasKey(proprietes => proprietes.CommercialId);
      });

      ab.Entity<Person>(entite =>
      {
        entite.HasKey(proprietes => proprietes.id);
      });

      ab.Entity<Subscription>(entite =>
      {
        entite.HasKey(proprietes => proprietes.SubscriptionID);
      });
    }





  }
}