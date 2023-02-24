using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace univassurence2.dataAccess.models
{
  public class Subscription
  {
    public int PersonID { get; set; }
    public int ProductID { get; set; }
    public int SubscriptionID { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public string SubscriptionState { get; set; } = String.Empty;
    public int ComercialID { get; set; }
    public DateTime SubscriptionTime { get; set; }

    public virtual Commercial Commercial { get; set; }
    public virtual Product Product { get; set; }
    public virtual Person Person { get; set; }
  }
}