using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univassurence2.BusinessLogic.Services;
using univassurence2.dataAccess.Data;

namespace univassurence2.BusinessLogic.Tests
{
  public class TestPerson
  {
    private PersonService _personService;

    private SouscriptionDbContext _souscriptionDbContext;

    [SetUp]
    public void Setup()
    {
      this._souscriptionDbContext = new SouscriptionDbContext();
      this._personService = new PersonService(_souscriptionDbContext);
    }

    [Test]
    public void TestPersonne()
    {
      var Ps = this._personService.GetPersons();
      Assert.IsNotNull(Ps);
    }
  }
}