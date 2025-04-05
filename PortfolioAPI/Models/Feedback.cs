using System.ComponentModel.DataAnnotations;


namespace PortfolioAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Someones too cool for a name";

        [Required]
        [Range(1, 3, ErrorMessage = "Response must be '1' '2' or '3'.")]
        public int Response { get; set; }
    }

}



