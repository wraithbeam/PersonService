using System;
using System.ComponentModel.DataAnnotations;
using PersonService.Models;

public class Person

{

    public int Id { get; set; }

    [Required]

    public string FirstName { get; set; }

    [Required]

    public string SecondName { get; set; }

    [Required]

    public string LastName { get; set; }

    public DateTime BirstDate { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }



    // Foreign Key 

    public int TitleId { get; set; }



    // Navigation property 

    public Title Title { get; set; }

}