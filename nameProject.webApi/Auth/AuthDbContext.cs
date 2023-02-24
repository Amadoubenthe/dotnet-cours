using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using nameProject.webApi.Auth;

namespace nameProject.webApi.Auth
{
  public class AuthDbContext : IdentityDbContext<ApplicationUser>
  {
    public AuthDbContext()
    {

    }


    public AuthDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      if (!options.IsConfigured)
      {
        options.UseSqlServer("Server=DESKTOP-U9KP4C1;Database=univ_db1;Trusted_Connection=True;Encrypt=False;User Id=sa;Password=1234");
      }
    }

  }
}