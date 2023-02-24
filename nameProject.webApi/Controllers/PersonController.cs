
using Microsoft.AspNetCore.Mvc;
using nameProject.webApi.logging;
using univassurence2.dataAccess.Data;
using univassurence2.BusinessLogic.Services;
using univassurence2.dataAccess.models;
using univassurence2.BusinessLogic.ModelsRewritten;
using Microsoft.AspNetCore.Authorization;

namespace nameProject.webApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PersonController : ControllerBase
  {
    private PersonService _personService;
    private Ilog ourLog;
    private SouscriptionDbContext dbContext;


    public PersonController(Ilog logger, SouscriptionDbContext dbContext)
    {
      this.ourLog = logger;
      this.dbContext = dbContext;
      this._personService = new PersonService(dbContext);
    }

    [HttpGet]
    [Route("persons")]
    public List<Person> GetAllPerson()
    {
      List<Person> p = this._personService.GetPersons();

      return p;
    }


    [HttpGet()]
    [Route(("persons/{id}"))]
    [AllowAnonymous]
    public IActionResult GetPerson(int id)
    {
      if (id != null)
      {

        Person person = this._personService.GetPersonById(id);

        if (person != null)
        {
          return Ok(person);
        }

      }

      return BadRequest("Missing Data");

    }

    [HttpPost]
    [Route("persons")]
    public IActionResult AddPerson([FromBody] PersonRequest personToAdd)
    {
      var person = new Person()
      {
        id = personToAdd.id,
        TypePart = personToAdd.TypePart,
        NumberTypePart = personToAdd.NumberTypePart,
        LastName = personToAdd.LastName,
        FirstName = personToAdd.FirstName,
        Phone = personToAdd.Phone,
        Sex = personToAdd.Sex,
        MaritalStatus = personToAdd.MaritalStatus,
        NumberChildren = personToAdd.NumberChildren,
        Employer = personToAdd.Employer
      };

      this._personService.AddPerson(person);

      return Ok(person);
    }

    [HttpDelete]
    [Route(("persons/{id}"))]
    public Boolean DeletePerson(int id)
    {
      if (id != null)
      {
        this._personService.DeletePerson(id);
        return true;
      }

      return false;
    }

    [HttpPut]
    [Route(("persons"))]
    public IActionResult UpdatePerson(PersonRequest personRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Missing required parameter");
      }
      else
      {
        if (personRequest != null)
        {
          Person person = new Person();
          person.id = personRequest.id;
          person.FirstName = personRequest.FirstName;
          person.LastName = personRequest.LastName;
          person.Phone = personRequest.Phone;
          person.Sex = personRequest.Sex;
          person.MaritalStatus = personRequest.MaritalStatus;
          person.NumberChildren = personRequest.NumberChildren;
          person.Employer = personRequest.Employer;
          person.NumberTypePart = personRequest.NumberTypePart;
          person.TypePart = personRequest.TypePart;

          return Ok(this._personService.UpdatePerson(person));
        }
        return null;
      }
    }


  }
}