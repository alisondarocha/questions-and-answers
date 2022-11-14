using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Q.A.__social_network.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }

        [Required, MaxLength(128)]
        public string? Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, MaxLength(128)]
        public string? Email { get; set; }
        
        public virtual ICollection<QuestionModel> Questions { get; set; }
    } 
}