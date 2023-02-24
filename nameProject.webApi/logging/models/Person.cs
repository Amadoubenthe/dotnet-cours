using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.models
{
    public class Person
    {
        public int PersonID { get; set; } 
        public string TypePart { get; set; } = string.Empty;
        public string NumberTypePart  { get; set; } = string.Empty;
        public string Name  { get; set; } = string.Empty;
        public string FirstName { get; set; }   = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public int NumberChildren { get; set; } = int.MaxValue;
        public string Employer { get; set; } = string.Empty;
    }
}