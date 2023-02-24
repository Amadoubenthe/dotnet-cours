using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univassurence2.dataAccess.models;
using univassurence2.dataAccess.Data;

namespace univassurence2.BusinessLogic.Services
{
  public class PersonService
  {
    private SouscriptionDbContext souscriptionDbContext;
    public PersonService(SouscriptionDbContext Context)
    {
      this.souscriptionDbContext = Context;
    }


    public List<Person> GetPersons()
    {
      return this.souscriptionDbContext.Person.ToList();
    }

    public Person GetPersonById(int id)
    {
      Person Person = souscriptionDbContext.Person.Where(c => c.id == id).FirstOrDefault();

      return Person;
    }


    public void AddPerson(Person? Person)
    {
      souscriptionDbContext.Person.Add(Person);
      souscriptionDbContext.SaveChanges();
    }

    public Person UpdatePerson(Person Person)
    {
      var personUpdate = souscriptionDbContext.Update(Person);

      if (personUpdate != null)
      {
        souscriptionDbContext.SaveChanges();
        return personUpdate.Entity;
      }

      return null;

    }

    public void DeletePerson(int id)
    {
      Person p = this.GetPersonById(id);

      Console.WriteLine("Deleted", id);

      if (p != null)
      {
        var R = souscriptionDbContext.Remove(p);

        if (R != null)
        {
          souscriptionDbContext.SaveChanges();
        }
      }
    }
  }
}