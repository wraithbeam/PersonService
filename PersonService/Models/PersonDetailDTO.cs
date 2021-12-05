using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonService.Models
{
    public class PersonDetailDTO

    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime BirstDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}