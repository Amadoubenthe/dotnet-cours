using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.Auth.Models
{
  public class NewUser
  {
    [Required(ErrorMessage = "The username and password")]
    public string? Username { get; set; }

    public string? Password { get; set; }


    [EmailAddress]
    public string? Email { get; set; }
  }
}