using System.ComponentModel.DataAnnotations;

namespace Q.A.__social_network.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, MaxLength(256)]
        public string? Email { get; set; }
    }
}