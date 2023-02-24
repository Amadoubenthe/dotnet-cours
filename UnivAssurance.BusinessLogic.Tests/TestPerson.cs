using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univassurence2.BusinessLogic.Services;
using univassurence2.dataAccess.Data;

namespace UnivAssurance.BusinessLogic.Tests
{
  public class TestPerson
  {
    private PersonService _PersonService;
    private SouscriptionDbContext _SouscriptionDbContext;

    [SetUp]
    public void Setup()
    {
      this._PersonService = new PersonService();
      this._SouscriptionDbContext = new SouscriptionDbContext();
    }

    [Test]
    public void TestGetPersons()
    {
      // var Ps = this._PersonService.
    }

    [Test]
    public void Test1()
    {
      Assert.Pass();
    }
  }
}