using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonService.Models
{
    public class PersonDTO

    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

    }
}