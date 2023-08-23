using System.ComponentModel.DataAnnotations;

namespace Game_Guns_of_the_Old_West.Models
{
    public class Player
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime SubmissionTime { get; set; }
    }



}
