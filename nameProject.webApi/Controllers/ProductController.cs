using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nameProject.webApi.logging;
using univassurence2.dataAccess.Data;
using univassurence2.BusinessLogic.Services;
using univassurence2.dataAccess.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace nameProject.webApi.Controllers
{
    [Authorize]
  public class ProductController
  {
    [HttpGet]
     [Route("products")]
    public string GetAllProducts()
    {
            // //   List<Person> p = this._personService.GetPersons();

            return "All products";
     }

  }
}