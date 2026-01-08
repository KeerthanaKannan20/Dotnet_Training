using System.ComponentModel.DataAnnotations;

namespace Task_Repository_Assignment.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
