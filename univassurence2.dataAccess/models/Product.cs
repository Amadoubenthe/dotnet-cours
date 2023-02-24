using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace univassurence2.dataAccess.models
{
  public class Product
  {

    public Product()
    {
      this.Subscription = new HashSet<Subscription>();
    }
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int price { get; set; }

    public string CampaignStartDate { get; set; }

    public string CampaignEndDate { get; set; }
    public virtual ICollection<Subscription> Subscription { get; set; }
  }
}