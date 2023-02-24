using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace univassurence2.dataAccess.models
{
  public class Person
  {
    public Person()
    {
      this.Subscription = new HashSet<Subscription>();
    }
    public int id { get; set; }
    public string TypePart { get; set; } = string.Empty;
    public string NumberTypePart { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string MaritalStatus { get; set; } = string.Empty;
    public int NumberChildren { get; set; }
    public string Employer { get; set; } = string.Empty;
    public virtual ICollection<Subscription> Subscription { get; set; }

  }
}