using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univassurence2.dataAccess.Data;

namespace univassurence2.BusinessLogic.Services
{
  public class ProductAssurenceService
  {

    private SouscriptionDbContext souscriptionDbContext;
    public ProductAssurenceService(SouscriptionDbContext Context)
    {
      this.souscriptionDbContext = Context;
    }

    public string GetProduct()
    {
      return "Bonjour";
    }


  }
}