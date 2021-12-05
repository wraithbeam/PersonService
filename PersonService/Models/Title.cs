using System.ComponentModel.DataAnnotations;



namespace PersonService.Models

{

    public class Title

    {
        public int Id { get; set; }

        [Required]

        public string Role { get; set; }

    }
}