using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace univassurence2.dataAccess.models
{
  public class Commercial
  {
    public Commercial()
    {
      this.Subscription = new HashSet<Subscription>();
    }
    public int CommercialId { get; set; }
    public string Name { get; set; }
    public string Matricule { get; set; }

    public virtual ICollection<Subscription> Subscription { get; set; }
  }
}